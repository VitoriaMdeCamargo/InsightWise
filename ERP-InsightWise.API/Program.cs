
using ERP_InsightWise.Database;
using ERP_InsightWise.Repository.Interface;
using ERP_InsightWise.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ERP_InsightWise.Database.Models;
using ERP_InsightWise.Service.CEP;
using ERP_InsightWise.API.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ERP_InsightWise.API.Configuration;
using System.Configuration;

namespace ERP_InsightWise.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICEPService, CEPService>();

            IConfiguration configuration = builder.Configuration;

            APPConfiguration appConfiguration = new APPConfiguration();

            builder.Services.Configure<APPConfiguration>(configuration);

            configuration.Bind(appConfiguration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(swagger =>
            {
                //Adiciona a possibilidade de enviar token para o controller
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                //Codigo para mudar a documentação do Swagger
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration.GetSection("Swagger:Title").Value,
                    Description = builder.Configuration.GetSection("Swagger:Description").Value
                    + "\n\n **Recomendação:** Para testes que solicitam um ID, use o ID 25, que estará previamente configurado no banco de dados.",
                    Contact = new OpenApiContact()
                    {
                        Email = builder.Configuration.GetSection("Swagger:Email").Value,
                        Name = builder.Configuration.GetSection("Swagger:Name").Value
                    }
                });
            });

            builder.Services.AddDbContext<FIAPDBContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("FIAPDatabase"),
                    b => b.MigrationsAssembly("ERP-InsightWise.Database"));
            });

            builder.Services.AddScoped<IRepository<Funcionario>, Repository<Funcionario>>();

            builder.Services.AddHealthCheck(appConfiguration);

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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health-check", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = HealthCheckExtensions.WriteResponse
                });
            });

            app.Run();
        }
    }
}
