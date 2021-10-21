using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos_chicken_backend.BussinessFlow;
using pos_chicken_backend.BussinessLogic;
using pos_chicken_backend.Data;
using pos_chicken_backend.Handler;
using pos_chicken_backend.Models;
using pos_chicken_backend.Repository;

namespace pos_chicken_backend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("postgres");
            var sqlConnectionStringReadOnly = Configuration.GetConnectionString("postgresReadOnly");
            services.AddScoped<MainContext>();

            //BussinessFlow
            services.AddScoped<HealthCheckBussinessFlow>();
            services.AddScoped<OrderBussinessFlow>();
            services.AddScoped<StockFlowBussinessFlow>();

            //BussinessLogic
            services.AddScoped<OrderLogic>();
            services.AddScoped<StockLogic>();

            //repository
            services.AddScoped<IBaseRepository, BaseRepository>();

            services.AddDbContext<MainContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("postgres")
                ));
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod();
                                  });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.UseCors(option => option.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
