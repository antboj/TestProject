﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using TestProject.Configuration;
using TestProject.Identity;

namespace TestProject.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // GitLab Test
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddSignalR();

            // Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info {Title = "TestProject API", Version = "v1"});
                options.DocInclusionPredicate((docName, description) => true);
                // Work with postman
                // application/x-www-form-urlencoded request or raw text request
                // grant_type=password&username=example&password=example&client_id=example&client_secret=example
                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "password",
                    AuthorizationUrl = "http://localhost:60087/connect/authorize",
                    TokenUrl = "http://localhost:60087/connect/token",
                    Scopes = new Dictionary<string, string>
                    {
                        {"deviceApi", "Device API" }
                    }
                });
            });

            // Configure Abp and Dependency Injection
            return services.AddAbp<TestProjectWebHostModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            app.UseStaticFiles();

            //app.UseJwtTokenMiddleware();
            app.UseMiddleware<MyAuthMiddleware>();

            app.UseAbpRequestLocalization();


            app.UseSignalR(routes => { routes.MapHub<AbpCommonHub>("/signalr"); });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "defaultWithArea",
                    "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.OAuthClientId("swaggerApi");
                options.OAuthAppName("Swagger API");
                options.OAuth2RedirectUrl("http://localhost:21021/swagger/oauth2-redirect.html");
                options.OAuthClientSecret("secret");
                options.SwaggerEndpoint(
                    _appConfiguration["App:ServerRootAddress"].EnsureEndsWith('/') + "swagger/v1/swagger.json",
                    "TestProject API V1");
                options.IndexStream = () => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("TestProject.Web.Host.wwwroot.swagger.ui.index.html");
            }); // URL: /swagger
        }
    }
}