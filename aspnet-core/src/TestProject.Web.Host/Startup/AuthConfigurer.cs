﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Abp.Runtime.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject.Web.Host.Startup
{
    public class AuthConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            //if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            //    services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = "JwtBearer";
            //        options.DefaultChallengeScheme = "JwtBearer";
            //    }).AddJwtBearer("JwtBearer", options =>
            //    {
            //        options.Audience = configuration["Authentication:JwtBearer:Audience"];

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            // The signing key must match!
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey =
            //                new SymmetricSecurityKey(
            //                    Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),

            //            // Validate the JWT Issuer (iss) claim
            //            ValidateIssuer = true,
            //            ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

            //            // Validate the JWT Audience (aud) claim
            //            ValidateAudience = true,
            //            ValidAudience = configuration["Authentication:JwtBearer:Audience"],

            //            // Validate the token expiry
            //            ValidateLifetime = true,

            //            // If you want to allow a certain amount of clock drift, set that here
            //            ClockSkew = TimeSpan.Zero
            //        };

            //        options.Events = new JwtBearerEvents
            //        {
            //            OnMessageReceived = QueryStringTokenResolver
            //        };
            //    });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Bearer";
                })
                .AddIdentityServerAuthentication(
                options =>
                {
                    options.Authority = "http://localhost:60087";
                    options.ApiName = "deviceApi";
                    options.EnableCaching = true;
                    options.RequireHttpsMetadata = false;
                    options.JwtBearerEvents.OnAuthenticationFailed += OnAuthenticationFailed;
                    options.JwtBearerEvents.OnTokenValidated += OnTokenValidated;
                    options.InboundJwtClaimTypeMap = new Dictionary<string, string>
                    {
                        {JwtRegisteredClaimNames.Sub, ClaimTypes.NameIdentifier }
                    };

                });
        }

        private static Task OnTokenValidated(TokenValidatedContext arg)
        {
            return Task.CompletedTask;
        }

        private static Task OnAuthenticationFailed(AuthenticationFailedContext arg)
        {
            return Task.CompletedTask;
        }


        /* This method is needed to authorize SignalR javascript client.
         * SignalR can not send authorization header. So, we are getting it from query string as an encrypted text. */
        private static Task QueryStringTokenResolver(MessageReceivedContext context)
        {
            if (!context.HttpContext.Request.Path.HasValue ||
                !context.HttpContext.Request.Path.Value.StartsWith("/signalr"))
                return Task.CompletedTask;

            var qsAuthToken = context.HttpContext.Request.Query["enc_auth_token"].FirstOrDefault();
            if (qsAuthToken == null) return Task.CompletedTask;

            // Set auth token from cookie
            context.Token = SimpleStringCipher.Instance.Decrypt(qsAuthToken, AppConsts.DefaultPassPhrase);
            return Task.CompletedTask;
        }
    }
}