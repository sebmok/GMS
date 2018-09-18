
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using MultitenantServer2016.CORE;
using MultitenantServer2016.CORE.Cache;
using Owin;
using ResourceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebConfigurationManager = System.Web.Configuration.WebConfigurationManager;

[assembly: OwinStartupAttribute(typeof(MultitenantServer2016.Startup))]
namespace MultitenantServer2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var issuer = WebConfigurationManager.AppSettings["Auth0Domain"];
            var audience = WebConfigurationManager.AppSettings["Auth0ClientID"];
            var secret = TextEncodings.Base64Url.Decode(
                WebConfigurationManager.AppSettings["Auth0ClientSecret"]);

            app.Use(async (ctx, next) =>
            {
                Tenant tenant = GetTenantBasedOnUrl(ctx.Request.Uri.Host);
                if (tenant == null)
                {
                    throw new ApplicationException("tenant not found");
                }
                ctx.Environment.Add("MultiTenant", tenant);
                await next();
            });

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                });
        }

        private Tenant GetTenantBasedOnUrl(string urlHost)
        {
            if (String.IsNullOrEmpty(urlHost))
            {
                throw new ApplicationException("urlHost must be specified");

            }
            Tenant tenant;

            string cacheName = "all-tentnts-cache-name";
            int cacheTimeOutSeconds = 30;

            List<Tenant> tenants =
               new TCache<List<Tenant>>().Get(
                    cacheName, cacheTimeOutSeconds,
                    () =>
                    {
                        List<Tenant> tenants1;
                        using (var context = new MultiTenantContext())
                        {
                            tenants1 = context.Tenant.ToList();
                        }
                        return tenants1;
                    });

            tenant = tenants.FirstOrDefault(a => a.DomainName.ToLower().Equals(urlHost)) ??
                tenants.FirstOrDefault(a => a.Default);

            if (tenant == null)
            {

                throw new ApplicationException("tenant not found based on URL, no default found");
            }

            return tenant;
        }
    }

}

