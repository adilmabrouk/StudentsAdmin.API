using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudentsAdmin.API.Models;
using StudentsAdmin.API.Repository;
using System;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace StudentsAdmin.API
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
            services.AddCors((options) =>
            {
                options.AddPolicy("angularApplication", (builder) =>
                {
                    builder.WithOrigins("*")
                     .AllowAnyHeader()
                     .WithMethods("GET", "POST", "PUT", "DELETE")
                     .WithExposedHeaders("*");
                });
            });

            services.AddControllers();
            services.AddDbContext<StudentAdminDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultCnx")));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IImageRepository, StorageImageRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentsAdmin.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
        }

        private int IStudentRepository()
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentsAdmin.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Resources")),
                RequestPath = "/Resources"
            });

            app.UseRouting();

            app.UseCors("angularApplication");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
