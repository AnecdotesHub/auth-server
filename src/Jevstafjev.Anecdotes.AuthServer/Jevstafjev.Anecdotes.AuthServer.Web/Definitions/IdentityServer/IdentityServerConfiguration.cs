using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace Jevstafjev.Anecdotes.AuthServer.Web.Definitions.IdentityServer;

public class IdentityServerConfiguration
{
    public static IEnumerable<Client> GetClients()
    {
        yield return new Client
        {
            ClientId = "swagger-client-id",
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = false,
            RequireConsent = false,
            RequirePkce = true,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Address,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "AnecdoteApi"
            },
            RedirectUris =
            {
                "https://localhost:7000/swagger/oauth2-redirect.html",
            },
            AllowedCorsOrigins = { "https://localhost:7000" }
        };
        yield return new Client
        {
            ClientId = "blazor-client",
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = false,
            RequireConsent = false,
            RequirePkce = true,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Address,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "AnecdoteApi"
            },
            RedirectUris =
            {
                "https://localhost:10001/swagger/oauth2-redirect.html",
                "https://localhost:5001/authentication/login-callback"
            },
            PostLogoutRedirectUris = { "https://localhost:5001/authentication/logout-callback" },
            AllowedCorsOrigins = { "https://localhost:5001" }
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        yield return new ApiResource("AnecdoteApi")
        {
            Scopes = { "AnecdoteApi" }
        };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        yield return new IdentityResources.OpenId();
        yield return new IdentityResources.Address();
        yield return new IdentityResources.Profile();
        yield return new IdentityResources.Email();
    }

    public static IEnumerable<ApiScope> GetScopes()
    {
        yield return new ApiScope("AnecdoteApi");
    }
}