using MediatR;

using Microsoft.EntityFrameworkCore;

using MyEcommerce.Api.Routes;
using MyEcommerce.Application.Data;
using MyEcommerce.Application.Dto;
using MyEcommerce.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IMyEcommerceDbContext, MyEcommerceDbContext>(o => o.UseSqlServer("connectionstring"));


builder.Services.AddMediatR(typeof(Result));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapProducts();


app.Run();

