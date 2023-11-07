using Microsoft.EntityFrameworkCore;
using Application.Infrastructure;
using Application.Core;
using Application.Data;
using Application.Services;
using Application.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connect with the DataBase

builder.Services.AddDbContext<ApplicationDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );


//Add the dependancy Injections
builder.Services.AddInfrastructureDepandancies();
builder.Services.AddServiceDependencies();
builder.Services.AddCoreDependencies();



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

app.Run();
