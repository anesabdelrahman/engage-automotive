using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Infrastructure;
using AutomotivePartsOrdering.Service.Infrastructure.Repository;
using AutomotivePartsOrdering.Service.Middleware;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();
builder.Services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
builder.Services.Configure<ProviderSettings>(builder.Configuration.GetSection("ProviderSettings"));
builder.Services.AddSingleton<IAuthorisationService, AuthorisationService>();
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:3000/")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
    .AddJsonFile("appsettings.json", false, reloadOnChange: true)
    .AddEnvironmentVariables();
var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();