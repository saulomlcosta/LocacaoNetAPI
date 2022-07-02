using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Application.Services;
using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Data.Repositories;
using LocacaoNetAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.RegisterServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LocacaoNetAPIContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DB_LOCACAO_PROD")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<ILocacaoService, LocacaoService>();




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
