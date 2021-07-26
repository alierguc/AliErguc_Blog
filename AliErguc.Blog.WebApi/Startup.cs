using AliErguc.Blog.Business.IoC.MicrosoftIoC;
using AliErguc.Blog.Core.Constants;
using AliErguc.Blog.WebApi.CustomFilters;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebApi
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
            services.AddAutoMapper(typeof(Startup));
        
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt=> {
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = JwtInfo.ISSUER,
                        ValidAudience = JwtInfo.AUDIENCE,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SECURITY_KEY)),
                        ValidateLifetime = true, // kullanýmý dolduðunda yok et
                        ValidateAudience = true,
                        ValidateIssuer = true, // 
                        ClockSkew = TimeSpan.Zero, // sunucular arasýnda zaman farký koyma.

                    };
                });
            services.AddDependencies();
            services.AddScoped(typeof(ValidId<>));
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AliErguc Blog Web API",
                    Description = "AliErguc Blog WebApi",
                    TermsOfService = new Uri("https://swagger.io/specification/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ali Ergüç",
                        Email = "alierguc1@gmail.com",
                        Url = new Uri("https://tr.linkedin.com/in/ali-erg%C3%BC%C3%A7-972ba6164"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Open Api License ",
                        Url = new Uri("https://swagger.io/license/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AliErguc Blog WebApi v1"));
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllers();
            });
        }
    }
}
