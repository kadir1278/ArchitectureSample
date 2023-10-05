using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.DependecyResolver;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Concrete;
using CoreLayer.Extensions;
using CoreLayer.Helper;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using MiddlewareLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScopedForMiddleware();
builder.Services.LoadModule();
builder.Services.AddDependencyResolvers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.Cookie.Name = "AcenteCRM";
    x.LoginPath = "/Authentication/Login";
    x.AccessDeniedPath = "/Authentication/LogOut";
});
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

app.GlobalFilter();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
