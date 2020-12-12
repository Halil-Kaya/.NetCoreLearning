using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UdemyIdentityServer.Client2
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

            services.AddAuthentication(opts => {

                opts.DefaultScheme = "Cookies";
                opts.DefaultChallengeScheme = "oidc";

            }).AddCookie("Cookies", opts => {

                opts.AccessDeniedPath = "/Home/AccessDenied";

            }).AddOpenIdConnect("oidc", opts => {

                opts.SignInScheme = "Cookies";
                opts.Authority = "https://localhost:44372/";
                opts.ClientId = "Client2-Mvc";
                opts.ClientSecret = "secret";
                opts.ResponseType = "code id_token";
                opts.GetClaimsFromUserInfoEndpoint = true;
                opts.SaveTokens = true;
                //scope.Add te talep ediyorum bana bunlari da ver diye eger izni varsa aliyor yoksa alamiyor
                opts.Scope.Add("api1.read");
                opts.Scope.Add("offline_access");


                //burdaki kismi kendim yaptim custom yani sistemin bunu tanimasi icin belirtmem lazim
                opts.Scope.Add("CountryAndCity");
                //burda belirtiyorum country claimine tokenden gelen countryi koy
                opts.ClaimActions.MapUniqueJsonKey("country", "country");
                //burda belirtiyorum city claimine tokenden gelen city koy
                opts.ClaimActions.MapUniqueJsonKey("city", "city");

                //burdan da role gelicek bunu rol bazli yetkilendirme icin yapicam
                opts.Scope.Add("Roles");
                opts.ClaimActions.MapUniqueJsonKey("role", "role");


                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {

                    RoleClaimType = "role"

                };

            });


            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
