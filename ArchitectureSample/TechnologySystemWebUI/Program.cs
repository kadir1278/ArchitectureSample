using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.DependecyResolver;
using CoreLayer.Helper;
using EntityLayer.Dto.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MiddlewareLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// yeni projeye geçiþte aþaðýdaki kod bloðu aktif edilmelidir
// Dependecy Start
builder.Services.LoadModule();
builder.Services.AddScopedForMiddleware();
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusinessModule()));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var tokens = builder.Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokens.Issuer,
            ValidAudience = tokens.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = EncryptionHelper.CreateSecurityKey(tokens.SecurityKey),
        };
    });
// Dependecy End

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
// middleware tetiklemeleri için aþaðýdaki kodun aktif edilmesi gerekmektedir
// middleware start
app.GlobalFilter();
// middleware end
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
