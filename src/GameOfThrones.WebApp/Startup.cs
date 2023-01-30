using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(GameOfThrones.WebApp.Startup))]

namespace GameOfThrones.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:44333",
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api1" }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new AuthorizeAttribute());
            app.UseWebApi(config);
        }
    }
}
