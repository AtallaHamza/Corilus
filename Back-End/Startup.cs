using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtallahHamza_Corilus.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AtallahHamza_Corilus
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(o => o.UseSqlServer(Configuration.GetConnectionString("Context")), ServiceLifetime.Scoped);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.2.1",
                    Title = "Corilus",
                    Description = "Test technique By Hamza",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Hamza Atallah",
                        Email = "hamza.atallah@esprit.tn",
                        Url = ""
                    },
                    License = new License
                    {
                        Name = "(c) Copyright 2019 Atallah Hamza, all rights reserved",
                        Url = ""
                    }
                });
            });

            services.AddCors();
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
                app.UseHsts();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CORILUS - API End Point");

                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
