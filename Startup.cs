using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Cadastro_TaxaBimestral_Protheus.Data;

namespace Cadastro_TaxaBimestral_Protheus
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
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromHours(int.MaxValue);
            //    options.IOTimeout = TimeSpan.FromHours(int.MaxValue);
            //});
            //string ConnectionStringFundos = Environment.GetEnvironmentVariable("taxa-bimestral-db-credentials");
            //string ConnectionStringFundos = Environment.ExpandEnvironmentVariables("%taxa-bimestral-db-credentials%");
            string ConnectionStringFundos = Configuration.GetConnectionString("Default_Servicos_Fundos");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(ConnectionStringFundos)
            );

            //string ConnectionStringProtheus = Configuration.GetConnectionString("Default_Servicos_Protheus");
            //services.AddDbContext<ApplicationContext>(options =>
            //    options.UseSqlServer(ConnectionStringProtheus)
            //);

            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            services.AddControllers()
                    .AddXmlSerializerFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
