using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repositories;
using UdemyNLayerProject.Data.UnitOfWorks;
using UdemyNLayerProject.Service.Services;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddHttpClient<CategoryApiService>(opt => {

                opt.BaseAddress = new Uri(Configuration["baseUrl"]);

            });

            services.AddScoped<NotFoundFilter>();

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(IService<>),typeof(Service<>));
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddDbContext<AppDbContext>(options =>{
                options.UseMySql(Configuration["ConnectionStrings:DefaultConnectionString"].ToString(),o => {
                    o.MigrationsAssembly("UdemyNLayerProject.Data");
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name : "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                
            });
        }
    }
}
