using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

namespace AspNetCoreVueStarter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!CommandLine.Arguments.TryGetOptions(args, true, out string mode, out ushort port, out bool https)) return;

            if (mode == "kill") {
                Console.WriteLine($"Killing process serving port {port}...");
                PidUtils.KillPort(port, true, true);
                return;
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
