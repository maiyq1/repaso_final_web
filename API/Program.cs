using API.Mapper;
using Data;
using Data.DBContext;
using Data.Model;
using Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IProductData, ProductData>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();
builder.Services.AddScoped<IMaintenanceData, MaintenanceData>();
builder.Services.AddScoped<IMaintenanceActivityDomain, MaintenanceActivityDomain>();
builder.Services.AddAutoMapper(
    typeof(ModelToRequest),
    typeof(RequestToAPI)
);


//MySQL Connection
var connectionString = builder.Configuration.GetConnectionString("databaseExample");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<IsaDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });


var app = builder.Build();

using(var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<IsaDBContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();