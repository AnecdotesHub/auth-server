﻿namespace Jevstafjev.Anecdotes.AuthServer.Web.Definitions.Base;

public abstract class AppDefinition : IAppDefinition
{
    public virtual void ConfigureServices(WebApplicationBuilder builder) { }

    public virtual void ConfigureApplication(WebApplication app) { }
}
