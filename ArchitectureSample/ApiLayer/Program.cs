using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.DependecyResolver;
using CoreLayer.Helper;
using EntityLayer.Dto.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MiddlewareLayer.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScopedForMiddleware();
builder.Services.AddSwaggerGen();
builder.Services.LoadModule();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.GlobalFilter();
app.UseAuthorization();

app.MapControllers();

app.Run();
