using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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



            services.AddDbContext<UdemyApiWithTokenDBContext>(options=> options.UseMySql(Configuration["ConnectionStrings:DefaultConnectionString"]));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {


                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("abc");
            app.UseCors();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
