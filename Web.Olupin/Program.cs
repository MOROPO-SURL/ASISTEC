using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.CompilerServices;
using System;

namespace MOROPO.ASISTEC.Web.Olupin
{
    public class Program
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
