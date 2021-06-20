using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var host= CreateHostBuilder(args).Build();
              using (var scope = host.Services.CreateScope())
             {
               // Retrieve your DbContext isntance here
                 var context = scope.ServiceProvider.GetRequiredService<AppDbCtx>();
                 if (context.Database.GetPendingMigrations().Any()) {
                    context.Database.Migrate();
                   } 
            }
          
          host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
