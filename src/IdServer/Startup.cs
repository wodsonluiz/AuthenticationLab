using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;

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

            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),

                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}
