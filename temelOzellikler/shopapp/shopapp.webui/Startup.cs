using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.business.Abstract;
using shopapp.business.Concrete;

namespace temelOzellikler
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
            services.AddScoped<IProductRepository,EfCoreProductRepository>();

            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<ICategoryService,CategoryManager>();
            
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //localhost:5001
            //localhost:5001/products            
            //localhost:5001/products/5            
            //localhost:5001/product/details/2

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name:"search",
                    pattern :"search",
                    defaults : new {Controller = "Shop" , action = "search"}
                );

                endpoints.MapControllerRoute(
                    name : "productdetails",
                    pattern : "{url}",
                    defaults : new {controller = "Shop",action = "details"}
                );

                endpoints.MapControllerRoute(
                    name : "products",
                    pattern : "products/{category?}",
                    defaults : new {controller = "Shop",action = "list"}
                );

                endpoints.MapControllerRoute(
                    name : "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });


        }
    }
}
