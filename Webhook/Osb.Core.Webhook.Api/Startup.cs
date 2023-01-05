using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Auth.Infrastructure.DependencyInjection.Extensions;
using Osb.Core.Platform.Business.Infrastructure.DependencyInjection.Extensions;
using Osb.Core.Platform.Integration.Infrastructure.DependencyInjection.Extensions;
using Osb.Core.Infrastructure.Data.DependecyInjection.Extensions;
using Osb.Core.Webhook.Infrastructure.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using Osb.Core.Webhook.Api.Filters;

namespace Osb.Core.Webhook.Api
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
            services.AddCors();
            services.AddControllers();

            Settings settings = Configuration.GetSection("Settings").Get<Settings>();

            services.AddSingleton(options => settings);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Osb.Core.Webhook.Api", Version = "v1" });
                c.OperationFilter<AddRequiredHearderParamenter>();
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization Header using the Basic Authorization scheme.",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string [] {}
                    }
                });
            });

            services.AddScopedAuthFactories();
            services.AddScopedBusinessFactories();
            services.AddScopedIntegrationFactories();
            services.AddScopedDbContext();
            services.AddTransientAuthFactories();
            services.AddTransientMiddlewareFactories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Osb.Core.Webhook.Api v1"));

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.Use((context, next) =>
                {
                    context.Request.EnableBuffering();
                    return next();
                });

            app.UseMiddleware<InputOutputMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
