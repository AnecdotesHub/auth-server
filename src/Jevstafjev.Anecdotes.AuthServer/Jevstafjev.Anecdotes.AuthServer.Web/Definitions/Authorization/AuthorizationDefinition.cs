using Jevstafjev.Anecdotes.AuthServer.Domain;
using Jevstafjev.Anecdotes.AuthServer.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.AuthServer.Web.Definitions.Authorization;

public class AuthorizationDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseCors(AppData.PolicyCorsName);
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
