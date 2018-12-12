using AngularTestApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularTestApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); ;
            services.AddCors (
                // options => options.AddPolicy ("DefaultCorsPolicy",
                //     builder => builder.WithOrigins ("http://localhost:4200")
                //     .AllowAnyHeader ()
                //     .AllowAnyMethod ()
                //     .AllowAnyOrigin ()
                //)
            );

            var connectionString = @"Data Source=localhost;Initial Catalog=angulartest;Persist Security Info=True;User ID=sa;Password=Aptean@123";
            services.AddDbContext<angulartestContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseCors (
                builder => builder.WithOrigins ("http://localhost:4200")
                .AllowAnyHeader ()
                .AllowAnyMethod ()
                .AllowAnyOrigin ()
                .AllowCredentials ()
            );
            app.UseMvc ();
        }
    }
}

// Scaffold-DbContext "Data Source=localhost;Initial Catalog=angulartest;Persist Security Info=True;User ID=sa;Password=Aptean@123" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

//public angulartestContext()
//{

//}

//public angulartestContext(DbContextOptions<angulartestContext> options) : base(options)
//{

//}