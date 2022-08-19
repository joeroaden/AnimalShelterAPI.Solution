using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace AnimalShelter
{
    public class Startup
    {
        // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5001", "http://localhost:5000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
            });

            services.AddDbContext<AnimalShelterContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();
            // services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            // services.AddScoped<IUserService, UserService>();
            
            // Updating the middlewear to use versioning.
            // services.AddApiVersioning(opt => {
            //     // this is going to return all available api versions
            //     opt.ReportApiVersions = true;

            //     opt.AssumeDefaultVersionWhenUnspecified = true;
            //     opt.DefaultApiVersion = new ApiVersion(1, 0);

            //     // Add Media type versioning
            //     opt.ApiVersionReader = ApiVersionReader.Combine(
            //         new HeaderApiVersionReader("x-api-version"),
            //         new MediaTypeApiVersionReader("x-api-version")
            //     );                
            // });
            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AnimalShelter API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Joe Roaden",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/joeroaden/AnimalShelter.Solution"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
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
            }

            // app.UseHttpsRedirection();

            //Enable middleware to serve generated Swagger as a Json endpoint
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            //Enable middle ware to serve swagger-ui (HTML, JS, CSS, etc.)
            //specify the Swagger JSON endpoint.
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My House Plant API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // app.UseCors();
            
            app.UseAuthorization();

            //  global cors policy
            // app.UseCors(x => 
            // {   x
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader();
            // });

            // custom jwt auth middleware
            // app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

