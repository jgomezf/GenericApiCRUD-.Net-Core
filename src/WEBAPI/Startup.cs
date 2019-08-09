using BLL.Implememtation;
using BLL.Interface;
using BLL.Utility;
using DAL;
using DAL.Contract;
using DAL.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace WEBAPI
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
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.BuildServiceProvider();
            services.AddSingleton<CountryBLL>();

            //services.AddDbContext<MyDBContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("MyDBContext")));

            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Generic CRUD ASP.NET Core Web API", Version = "v1", Description= "ASP.NET Core Web API" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddHttpClient();
            services.AddDbContext<MyDBContext>();
            services.AddScoped<DbContext, MyDBContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPersonBLL, PersonBLL>();
            services.AddTransient<ICountryBLL, CountryBLL>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Generic CRUD ASP.NET Core Web API");
           });
            app.UseHttpsRedirection();
            app.UseMvc();
                        
        }
    }
}
