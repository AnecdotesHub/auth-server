using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace Jevstafjev.Anecdotes.AuthServer.Web.Definitions.IdentityServer;

public class IdentityServerConfiguration
{
    public static IEnumerable<Client> GetClients()
    {
        yield return new Client
        {
            ClientId = "anecdote-swagger-id",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = true,
            RequirePkce = false,
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
                "https://localhost:7001/swagger/oauth2-redirect.html",
            },
            AllowedCorsOrigins = { "https://localhost:7001" }
        };
        yield return new Client
        {
            ClientId = "subscriber-swagger-id",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = true,
            RequirePkce = false,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Address,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "SubscriberApi"
            },
            RedirectUris =
            {
                "https://localhost:8001/swagger/oauth2-redirect.html",
            },
            AllowedCorsOrigins = { "https://localhost:8001" }
        };
        yield return new Client
        {
            ClientId = "notification-swagger-id",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = true,
            RequirePkce = false,
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Address,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "Notification"
            },
            RedirectUris =
            {
                "https://localhost:9001/swagger/oauth2-redirect.html",
            },
            AllowedCorsOrigins = { "https://localhost:9001" }
        };
        yield return new Client
        {
            ClientId = "blazor-client-id",
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
                "https://localhost:5001/authentication/login-callback"
            },
            PostLogoutRedirectUris = { "https://localhost:5001/authentication/logout-callback" },
            AllowedCorsOrigins = { "https://localhost:5001" }
        };
        yield return new Client
        {
            ClientId = "notification-service-client",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = { "SubscriberApi" }
        };
        yield return new Client
        {
            ClientId = "anecdote-service-client",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = { "Notification" }
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        yield return new ApiResource("AnecdoteApi")
        {
            Scopes = { "AnecdoteApi" }
        };
        yield return new ApiResource("SubscriberApi")
        {
            Scopes = { "SubscriberApi" }
        };
        yield return new ApiResource("Notification")
        {
            Scopes = { "Notification" }
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
        yield return new ApiScope("SubscriberApi");
        yield return new ApiScope("Notification");
    }
}