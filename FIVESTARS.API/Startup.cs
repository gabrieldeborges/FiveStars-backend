using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FIVESTARS.Infra.Data;
using FIVESTARS.Infra.Repository;
using FIVESTARS.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Dapper;
using FIVESTARS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using FIVESTARS.Domain.Handlers;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace FIVESTARS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConnectionStrings:connection"];
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddJsonOptions(options => options.JsonSerializerOptions. = new DefaultContractResolver());
            services.AddDbContext<Context>(opt => opt.UseMySql(connection, ServerVersion.AutoDetect(connection)));

            AddRepositories(services);

            services.AddResponseCompression();

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddSwaggerGen();

            //services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });


            AddHandlers(services);

            MapEntities();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseHttpsRedirection();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ITesteRepository, TesteRepository>();
            services.AddTransient<IBedroomRepository, BedroomRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
        }

        private void AddHandlers(IServiceCollection services)
        {
            services.AddTransient<TesteHandler, TesteHandler>();
            services.AddTransient<BedroomHandler, BedroomHandler>();
            services.AddTransient<ClientHandler, ClientHandler>();
        }

        private void MapEntities()
        {
            MapEntity(typeof(Teste));
            MapEntity(typeof(Client));
            MapEntity(typeof(Bedroom));
        }

        private void MapEntity(Type entityType)
        {
            SqlMapper.SetTypeMap(entityType, new CustomPropertyTypeMap(
                entityType, (type, columnName) =>
                type.GetProperties().FirstOrDefault(prop =>
                    prop.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(attr => attr.Name == columnName)
                )
            ));
        }
    }
}
