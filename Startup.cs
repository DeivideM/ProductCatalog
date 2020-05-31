using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProductCatalog.Data;
using ProductCatalog.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddResponseCaching();
            services.AddResponseCompression();
            //services.AddScoped<StoreContextDb, StoreContextDb>();

            services.AddDbContext<StoreContextDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StoreDbConnection"));
            }
            );

            services.AddTransient<ProductRepository, ProductRepository>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Deivide Store", Version = "v1" });
            });

            //services.AddMvc();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Deivide - My API v1");
            });
        }
    }
}
