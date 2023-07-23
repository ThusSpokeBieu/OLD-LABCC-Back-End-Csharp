using System.Net.Sockets;
using System.Text;
using LABCC.BackEnd.Application.UseCases;
using LABCC.BackEnd.Domain.Entities.Usuarios;
using LABCC.BackEnd.Infrastructure.Config;
using LABCC.BackEnd.Infrastructure.Context;
using LABCC.BackEnd.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using LABCC.BackEnd.Domain.Entities.Colecoes;
using LABCC.BackEnd.Application.Mappers;
using LABCC.BackEnd.Domain.Entities.Modelos;
using LABCC.BackEnd.Domain.Entities.Usuarios.Interfaces;
using LABCC.BackEnd.Application.UseCases.Interfaces;
using LABCC.BackEnd.Domain.Entities.Colecoes.Interfaces;
using LABCC.BackEnd.Domain.Entities.Modelos.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using IdentityRole = Microsoft.AspNet.Identity.EntityFramework.IdentityRole;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

//JWT
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");

var connectionString =
    $"Server={dbHost},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=true;MultipleActiveResultSets=true";
builder.Services.AddDbContext<MsSqlContext>(options => options.UseSqlServer(connectionString));

IdentityBuilderExtensions.AddDefaultTokenProviders(builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<MsSqlContext>());
    
var config = builder.Configuration;
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
{
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!)),
    ValidateIssuerSigningKey = true,
    ValidateLifetime = true,
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioUseCases, UsuarioUseCases>();
builder.Services.AddAutoMapper(typeof(UsuarioMapper));

builder.Services.AddScoped<IColecaoRepository, ColecaoRepository>();
builder.Services.AddScoped<IColecaoService, ColecaoService>();
builder.Services.AddScoped<IColecaoUseCases, ColecaoUseCases>();
builder.Services.AddAutoMapper(typeof(ColecaoMapper));

builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<IModeloService, ModeloService>();
builder.Services.AddScoped<IModeloUseCases, ModeloUseCases>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
