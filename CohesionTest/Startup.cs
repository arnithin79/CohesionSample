using Cohesion.Base.Models;
using Cohesion.Entities;
using Cohesion.Services.Repositories.BaseRepository;
using Cohesion.Services.Services.EmailService;
using Cohesion.Services.Services.FakeService;
using Cohesion.Services.Services.ServiceRequest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CohesionTest
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

            services.AddControllers();

            services.AddDbContext<CohesionDBContext>(opt => opt.UseInMemoryDatabase(databaseName: "CohesionTest"));

            IConfigurationSection emailSettingsSection = Configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(emailSettingsSection);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IServiceRequestService, ServiceRequestService>();

            services.AddSingleton<IEmailService, EmailService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CohesionTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CohesionTest v1"));
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(exc =>
            {
                exc.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                });
            });

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
