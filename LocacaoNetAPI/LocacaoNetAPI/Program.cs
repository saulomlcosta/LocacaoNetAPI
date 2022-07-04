using LocacaoNetAPI.Application.AutoMapper;
using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Application.Services;
using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Data.Repositories;
using LocacaoNetAPI.Domain.Interfaces;
using LocacaoNetAPI.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));
builder.Services.RegisterServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LocacaoNetAPIContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DB_LOCACAO_PROD")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt => { opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });


builder.Services.AddCors();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
