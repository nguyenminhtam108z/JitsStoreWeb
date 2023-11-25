
using JitsDataAccess.Data;
using JitsDataAccess.Repository;
using JitsDataAccess.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<JitsStoreContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICacheRedis, CacheService>();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
	string connection = builder.Configuration
		.GetConnectionString("Redis");
	redisOptions.Configuration = connection;
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
