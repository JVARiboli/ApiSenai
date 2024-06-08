using AutoMapper;
using Senai.Domain.Interfaces;
using Senai.Repository.Context;
using Senai.Repository.Repositories;
using Senai.Service.Interfaces;
using Senai.Service.Services;

namespace Senai.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SenaiContext>();

            #region Injeção Services

            builder.Services.AddScoped<IEscolaService, EscolaService>();

            // Usou a aplicacao, depois ele derruba
            //builder.Services.AddTransient<>();

            //fica para sempre a aplicacao erguida
            //builder.Services.AddSingleton<>();

            #endregion

            #region Injeção Repositórios

            builder.Services.AddScoped<IEscolaRepository, EscolaRepository>();

            #endregion

            #region Automapper

            MapperConfiguration mapperConfiguration = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(new[] { "Senai.Service" });
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai v1");
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
