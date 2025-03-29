using Jevstafjev.Anecdotes.AuthServer.Infrastructure.DatabaseInitialization;
using Jevstafjev.Anecdotes.AuthServer.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.AuthServer.Web.Definitions.DatabaseInitialization;

public class DatabaseInitializationDefinition : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        DatabaseInitializer.SeedUsers(app.Services).Wait();
    }
}
