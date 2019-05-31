using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject.Web.Host.Startup
{
    public class MyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public MyAuthMiddleware(RequestDelegate next, IAuthenticationSchemeProvider schemes)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));
            if (schemes == null)
                throw new ArgumentNullException(nameof(schemes));
            this._next = next;
            this.Schemes = schemes;
        }

        public IAuthenticationSchemeProvider Schemes { get; set; }

        public async Task Invoke(HttpContext context)
        {
            context.Features.Set<IAuthenticationFeature>((IAuthenticationFeature)new AuthenticationFeature()
            {
                OriginalPath = context.Request.Path,
                OriginalPathBase = context.Request.PathBase
            });
            IAuthenticationHandlerProvider handlers = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            foreach (AuthenticationScheme authenticationScheme in await this.Schemes.GetRequestHandlerSchemesAsync())
            {
                IAuthenticationRequestHandler handlerAsync = await handlers.GetHandlerAsync(context, authenticationScheme.Name) as IAuthenticationRequestHandler;
                bool flag = handlerAsync != null;
                if (flag)
                    flag = await handlerAsync.HandleRequestAsync();
                if (flag)
                    return;
            }
            AuthenticationScheme authenticateSchemeAsync = await this.Schemes.GetDefaultAuthenticateSchemeAsync();
            if (authenticateSchemeAsync != null)
            {
                AuthenticateResult authenticateResult = await context.AuthenticateAsync(authenticateSchemeAsync.Name);
                if (authenticateResult?.Principal != null)
                {
                    context.User = authenticateResult.Principal;
                }
                    
                    
            }
            await this._next(context);
        }
    }
}
