using System;
using System.Text;
using againAndAgainWhenWillYouStop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace againAndAgainWhenWillYouStop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            
            services.AddDbContext<ApplicationIdentityDbContext>(options => {
                options.UseMySql("server=127.0.0.1;port=3306;username=root;password=;database=again");
            });


            services.AddIdentity<ApplicationUser,ApplicationRole>(options => {

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.AllowedUserNameCharacters = "abcçdefgğhiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ0123456789-._";

            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => {

                options.Cookie.Name = "member_cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(90);
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
                options.LoginPath = new PathString("/Home/Login");
                //kisi sistemden cikarken buraya yonlendircem
                options.LogoutPath = new PathString("/Member/Logout");
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            });

            services.AddSession(options => {

                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = "member_cookie";

            });


            services.AddAuthentication(options => {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options => {

                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters(){
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://google.com",
                    ValidIssuer = "http://google.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"))
                };
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Check}/{id?}");
            });
        }
    }
}
