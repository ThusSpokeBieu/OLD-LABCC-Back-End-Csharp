using LABCC.BackEnd.Application.UseCases;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Infrastructure.Config;
using LABCC.BackEnd.Infrastructure.Context;
using LABCC.BackEnd.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Application.Mappers;
using LABCC.BackEnd.Domain.Entities.Modelos;

var builder = WebApplication.CreateBuilder(args);


DotEnv.Load();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Server={dbHost},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};Trusted_Connection=False;TrustServerCertificate=true;MultipleActiveResultSets=true";
builder.Services.AddDbContext<MsSqlContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<UsuarioRepository>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddTransient<UsuarioUseCases>();
builder.Services.AddAutoMapper(typeof(UsuarioMapper));

builder.Services.AddTransient<ColecaoRepository>();
builder.Services.AddTransient<ColecaoService>();
builder.Services.AddTransient<ColecaoUseCases>();
builder.Services.AddAutoMapper(typeof(ColecaoMapper));

builder.Services.AddTransient<ModeloRepository>();
builder.Services.AddTransient<ModeloService>();
builder.Services.AddTransient<ModeloUseCases>();
builder.Services.AddAutoMapper(typeof(ModeloMapper));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  var context = services.GetRequiredService<MsSqlContext>();
  context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
