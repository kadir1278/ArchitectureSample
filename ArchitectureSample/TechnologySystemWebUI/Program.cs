using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.DependecyResolver;
using CoreLayer.Helper;
using EntityLayer.Dto.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using MiddlewareLayer.Extensions;
using CoreLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// yeni projeye ge�i�te a�a��daki kod blo�u aktif edilmelidir
// Dependecy Start
builder.Services.LoadModule();
builder.Services.AddScopedForMiddleware();
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusinessModule()));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var tokens = builder.Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(opts =>
    {
        opts.Cookie.Name = $"Authorization";
        opts.AccessDeniedPath = "/admin/login";
        opts.LoginPath = "/admin/login";
        opts.SlidingExpiration = true;
        opts.ExpireTimeSpan = TimeSpan.FromMinutes(tokens.AccessTokenExpiration);
    })
    .AddJwtBearer(options =>
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

builder.Services.RateLimitByPolicyName("AuthLimit", TimeSpan.FromMinutes(1), 5);

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
// middleware tetiklemeleri i�in a�a��daki kodun aktif edilmesi gerekmektedir
// middleware start
app.GlobalFilter();
// middleware end
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "DashboardIndex",
            areaName: "Admin",
            pattern: "{area}/{controller}/{action}/{id?}");

app.Run();
