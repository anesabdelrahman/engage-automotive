using AutomotivePartsOrdering.Service.Application;
using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using AutomotivePartsOrdering.Service.Infrastructure;
using AutomotivePartsOrdering.Service.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();