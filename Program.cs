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

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            if (https) app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!app.Environment.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (app.Environment.IsDevelopment())
                {
                    if (mode == "start")
                    {
                        spa.UseVueCli(npmScript: "serve", port: port, forceKill: true, https: https);
                    }

                    if (mode == "attach")
                    {
                        spa.UseProxyToSpaDevelopmentServer($"{(https ? "https" : "http")}://localhost:{port}");
                    }
                }
            });

            app.Run();
        }
    }
}
