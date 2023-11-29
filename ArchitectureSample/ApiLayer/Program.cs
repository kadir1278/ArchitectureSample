using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.DependecyResolver;
using IntegrationLayer.DependecyResolver;
using MiddlewareLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScopedForMiddleware();
builder.Services.LoadModule();
builder.Services.IntegrationLoadModule();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusinessModule()));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

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
