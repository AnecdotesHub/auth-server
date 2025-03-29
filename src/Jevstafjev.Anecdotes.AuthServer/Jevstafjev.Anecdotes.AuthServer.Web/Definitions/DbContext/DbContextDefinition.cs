using Jevstafjev.Anecdotes.AuthServer.Infrastructure;
using Jevstafjev.Anecdotes.AuthServer.Web.Definitions.Base;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Anecdotes.AuthServer.Web.Definitions.DbContext;

public class DbContextDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));
            options.UseSqlServer(connectionString);
        });
    }
}
