using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UdemyApiWithToken.Domain;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Repositories;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;
using UdemyApiWithToken.Security.Token;
using UdemyApiWithToken.Services;

namespace UdemyApiWithToken
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


            services.AddDbContext<UdemyApiWithTokenDBContext>(options=> options.UseMySql(Configuration["ConnectionStrings:DefaultConnectionString"]));
            services.AddControllers();

            services.AddScoped<Domain.Services.IAuthenticationService, Services.AuthenticationService>();
            services.AddScoped<ITokenHandler,TokenHandler>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            services.AddCors(opts => {
               
               
                opts.AddDefaultPolicy(builder => {

                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
/*
                opts.AddPolicy("abc", builder => {

                    builder.WithOrigins("https://www.abc.com").AllowAnyHeader().AllowAnyMethod();

                });
*/
            });


            //eğer projemin Herhangi bir yerinde TokenOptions görürse bunu appsettings.json dosyasında ki TokenOptions olarak alıcak
            //daha iyi anlatmak gerekirse bunun bir aşağısında yazdığım getSection kısmını her yerde yazmama gerek kalmiyacak
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtbeareroptions => {

                jwtbeareroptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters(){


                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey)

                };


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

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseCors("abc");
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
