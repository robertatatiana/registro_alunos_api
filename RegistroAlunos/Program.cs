using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RegistroAlunos.Data;
using RegistroAlunos.Repositorios;
using RegistroAlunos.Repositorios.Interfaces;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "RegistroAlunos", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            x.IncludeXmlComments(xmlPath);
        });

        //adicionar o contexto do banco de dados
        builder.Services.AddEntityFrameworkSqlServer().AddDbContext<AppDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

        builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();

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
    }
}