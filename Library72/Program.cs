using System.Text.Json.Serialization;
using Library72.Application;
using Library72.CustomSwaggerOperationFilters;
using Library72.Extensions;
using Library72.Filters;
using Library72.Storage.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
.AddDbContext<Test72Context>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
    .AddControllers(options =>
        options.Filters.Add<CustomExceptionsFilterAttribute>())
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddODataModelBuilder();

builder.Services.AddApiServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastrucutreServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<OdataOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<HttpExceptionMiddleware>();
app.Run();
