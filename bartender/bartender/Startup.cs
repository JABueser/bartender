using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bartender.Data;
using bartender.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bartender
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BartenderDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Bartender")));
            services.AddScoped<IDrinkData, SqlDrinkData>();

            services.AddScoped<IDrinkData, SqlDrinkData>();
            services.AddScoped<IOrderData, SqlOrderData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(ConfigureRoutes);

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index

            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
