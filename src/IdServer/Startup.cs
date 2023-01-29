using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin;
using Owin;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace IdServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            var path = Path.GetFullPath("IdServer_TemporaryKey.pfx").Replace("\\bin\\Debug", "");
            var cert = new X509Certificate2(path, "ge&m9g84jTREi3?S");

            var factory = new IdentityServerServiceFactory();

            //Users
            var users = new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "1234567",
                    Username = "NedStark",
                    Password= "NedStark",
                    Claims = new List<Claim>
                    {
                        new Claim("email", "wodsonluiz@live.com"),
                        new Claim("name", "NedStark"),
                        new Claim("role", "user"),
                        new Claim("role", "manager")
                    }
                }
            };

            //Clients
            var clients = new List<Client>
            {
                new Client
                {
                    ClientId = "GameOfThrones.WebApp",
                    ClientName = "Game Of Thrones Web App",
                    RedirectUris = { "https://localhost:44317" },
                    AllowedScopes = { "openid", "email", "profile", "gotscope"},
                    Flow = Flows.Implicit
                }
            };

            //Scopes

            var scopes = new List<Scope>
            {
                StandardScopes.EmailAlwaysInclude,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.OpenId,
                new Scope
                {
                    Name = "gotscope",
                    DisplayName = "Got Info",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("https://localhost:44317/api/weatherforecast")
                    }
                }
            };

            factory.UseInMemoryUsers(users);
            factory.UseInMemoryClients(clients);
            factory.UseInMemoryScopes(scopes);

            //Setup
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "localhost",
                SigningCertificate = cert,
                Factory = factory
            });
        }
    }
}
