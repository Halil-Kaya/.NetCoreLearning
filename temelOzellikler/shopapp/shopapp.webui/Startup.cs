using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.business.Abstract;
using shopapp.business.Concrete;
using shopapp.webui.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using shopapp.webui.EmailServices;
using Microsoft.Extensions.Configuration;

namespace temelOzellikler
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration){
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseMySql("server=127.0.0.1;port=3305;username=root;password=;database=shop"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>{
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options => {
                
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/acount/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.Cookie = new CookieBuilder{
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict 
                };

            });

            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
            services.AddScoped<IProductRepository,EfCoreProductRepository>();

            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<ICategoryService,CategoryManager>();

            services.AddScoped<IEmailSender,SmtpEmailSender>(i =>
                 new SmtpEmailSender(
                     _configuration["EmailSender:Host"],
                     _configuration.GetValue<int>("EmailSender:Port"),
                     _configuration.GetValue<bool>("EmailSender:EnableSSl"),
                     _configuration["EmailSender:UserName"],
                     _configuration["EmailSender:Password"]
                     ));
            
            
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
            
            
            app.UseAuthentication();
            app.UseRouting();  
            app.UseAuthorization();

             

            //localhost:5001
            //localhost:5001/products            
            //localhost:5001/products/5            
            //localhost:5001/product/details/2

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name : "adminproducts",
                    pattern : "admin/products",
                    defaults : new {Controller = "Admin",action = "ProductList"}
                );

                endpoints.MapControllerRoute(
                    name : "adminproductcreate",
                    pattern : "admin/products/create",
                    defaults : new {Controller = "Admin",action = "ProductCreate"}
                );

                endpoints.MapControllerRoute(
                    name : "adminproductedit",
                    pattern : "admin/products/{id?}",
                    defaults : new {Controller = "Admin",action = "ProductEdit"}
                );

                endpoints.MapControllerRoute(
                    name : "admincategories",
                    pattern : "admin/categories",
                    defaults : new {Controller = "Admin",action = "CategoryList"}
                );

                endpoints.MapControllerRoute(
                    name : "admincategorycreate",
                    pattern : "admin/categories/create",
                    defaults : new {Controller = "Admin",action = "CategoryCreate"}
                );

                endpoints.MapControllerRoute(
                    name : "admincategoryedit",
                    pattern : "admin/categories/{id?}",
                    defaults : new {Controller = "Admin",action = "CategoryEdit"}
                );


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
