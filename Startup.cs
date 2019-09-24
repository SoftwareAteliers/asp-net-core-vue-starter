using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

namespace AspNetCoreVueStarter
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
            services.AddControllersWithViews();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

#if DEBUG
                if (System.Diagnostics.Debugger.IsAttached)
                    endpoints.MapToVueCliProxy("{*path}", new SpaOptions { SourcePath = "ClientApp" }, "serve", regex: "Compiled successfully");
                else
#endif
                    // note: output of vue cli or quasar cli should be wwwroot
                    endpoints.MapFallbackToFile("index.html");
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        // run npm process with client app
            //        spa.UseVueCli(npmScript: "serve", port: 8080);
            //        // if you just prefer to proxy requests from client app, use proxy to SPA dev server instead:
            //        // app should be already running before starting a .NET client
            //        // spa.UseProxyToSpaDevelopmentServer("http://localhost:8080"); // your Vue app port
            //    }
            //});
        }
    }
}
