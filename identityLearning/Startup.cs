using identityLearning.CustomValidation;
using identityLearning.EmailServices;
using identityLearning.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace identityLearning
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


            services.AddScoped<TwoFactorService.TwoFactorService>();

            services.AddTransient<IAuthorizationHandler,ExpireDateExchangeHandler>();


            services.AddDbContext<AppIdentityDbContext>(options => {
                options.UseMySql(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });


            //claim bazli yetkilendirme yaptim!
            services.AddAuthorization(opts => {

                opts.AddPolicy("AnkaraPolicy",policy => {
                    //burdaki claimin anlami su eger cookie nin icinde city var ve degeri ankara ise dogru boylece AnkaraPolicy etiketini verdigin
                    //endpoinlerde cityi ankara olanlar erisebilir
                    policy.RequireClaim("city","ankara");

                });

                opts.AddPolicy("ViolencePolicy",policy => {
                    //burda ise cookie nin icinde violence varsa anlami geliyor icindeki degere bakmiyorum cookienin icinde violence olmasi yeterli
                    //eger violence var ise yasi 15 ten buyuk anlamina gelmektedir
                    policy.RequireClaim("violence");

                });

                opts.AddPolicy("ExchangePolicy",policy => {

                    policy.AddRequirements(new ExpireDateExchangeRequirement());

                });

            });

            services.AddAuthentication().AddFacebook(opts => {
                
                opts.AppId = Configuration["Authentication:Facebook:AppId"];
                opts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];

            });
            


            services.AddScoped<IEmailSender,SmtpEmailSender>(i =>
                 new SmtpEmailSender(
                     Configuration["EmailSender:Host"],
                     Configuration.GetValue<int>("EmailSender:Port"),
                     Configuration.GetValue<bool>("EmailSender:EnableSSl"),
                     Configuration["EmailSender:UserName"],
                     Configuration["EmailSender:Password"]
                     ));
            


            services.AddIdentity<AppUser,AppRole>(opts => {
                //kendime göre özelleştirebiliyorum(şifre kısımlarını)
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

                //mail kısımları
                //maillerin unique olmasını belirttim
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcçdefgğhiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ0123456789-._";

            
            })
            .AddDefaultTokenProviders()
            .AddPasswordValidator<CustomPasswordValidator>()//şifre hatalarını kendim kontrol ediyorum
            .AddUserValidator<CustomUserValidator>()//kullanıcıyla ilgili hataları kendim kontrol ediyorum
            .AddErrorDescriber<CustomIdentityErrorDescriber>()//hataların sonucunda dönecek olanları kendim kontrol ediyorum (türkçeye çevirttim)
            .AddEntityFrameworkStores<AppIdentityDbContext>();


            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "MyBlog";
            cookieBuilder.HttpOnly = false;
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;


            services.ConfigureApplicationCookie(opts => {
                //eger kisi giriş yapmamissa buraya yonlendircem
                opts.LoginPath = new PathString("/Home/Login");
                //kisi sistemden cikarken buraya yonlendircem
                opts.LogoutPath = new PathString("/Member/Logout");
                //kendi cookiemi kullancam onu belirtiyorum
                opts.Cookie = cookieBuilder;
                //cookie yi tekrar olustursun anlamine geliyor
                opts.SlidingExpiration = true;
                //60 gun giris yapmazsa kisi tekrar giris yapsin
                opts.ExpireTimeSpan = System.TimeSpan.FromDays(60);
                //NOT AcessDenied kullanici yok giris yapamaz anlamina degil kullanicinin yetkisi yok anlamina gelmekte o mantikla calisiyor!
                opts.AccessDeniedPath = new PathString("/Member/AccessDenied");
            });

            //claims islemlerinde benim olusturdugum claim olarak sekillensin diye scoped icinde olusturuyorum kendi custom claim im ClaimProvider dosyasinin icinde!
            services.AddScoped<IClaimsTransformation,ClaimProvider.ClaimProvider>();

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

            
            app.UseStatusCodePages();
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
