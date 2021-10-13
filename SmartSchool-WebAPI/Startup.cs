using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Core;
using SmartSchool.Core.Helper.ExtensionMethods;
using SmartSchool.WebAPI.Helper.ExtensionMethods;

namespace SmartSchool.WebAPI
{
    public class Startup
    {
        public virtual IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Database
            services.AddDbContext<DataContext>(x => x
                .UseLazyLoadingProxies()
                .UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnSql"),
                    x => x.MigrationsAssembly(typeof(DataContext).Assembly.GetName().Name)
                )
            );

            //Repositories
            services.AddRepositories();

            //Services
            services.AddServices();


            //AutoMapper
            services.AddAutoMapper(config =>
            {
                config.ForAllMaps((typeMap, config) =>
                {
                    config.ForAllMembers(opt =>
                    {
                        opt.Condition((sourceObject, destObject, sourceProperty, destProperty) =>
                        {
                            if (sourceProperty == null)
                            {
                                return destProperty != null;
                            }
                            return !sourceProperty.Equals(destProperty);
                        });
                    });
                });
            }, typeof(Startup).Assembly);

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartSchool.WebAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartSchool.WebAPI v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
