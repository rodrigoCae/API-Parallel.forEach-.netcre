using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cadastro_TaxaBimestral_Protheus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(300); });
                webBuilder.UseKestrel(o => { o.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(300); });
                //webBuilder.UseHttpSys(s => { s.MaxRequestBodySize = null; });
                //webBuilder.UseHttpSys(s => { s. = int.MaxValue; });
                });
    }
}
