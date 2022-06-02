using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection;
using Secret = IdentityServer4.Models.Secret;

namespace IdentityServer.Core.Data
{
    public static class Config
    {
        public static List<Client> Clients = new List<Client>
        {
                new Client
                {
                    ClientId = "identity-server-demo-web",
                    AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RedirectUris = new List<string> { "http://localhost:3006/signin-callback.html" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:3006/" },
                    ClientSecrets =
                    {
                        new IdentityServer4.Models.Secret("secret".Sha256())
                    },
                    AllowedScopes = { "myApi.read", "myApi.write", "write", "read", "openid", "profile", "email" },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:3006",
                    },
                    AccessTokenLifetime = 86400
                }
        };

        public static List<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "identity-server-demo-api",
                DisplayName = "Identity Server Demo API",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            },   new ApiResource("myApi")
            {
                Scopes = new List<string>{ "myApi.read","myApi.write" },
                ApiSecrets = new List<IdentityServer4.Models.Secret>{ new Secret("supersecret".Sha256()) }
            },
            new ApiResource("myApi1")
            {
                Scopes = new List<string>{ "myApi.read","myApi.write" },
                ApiSecrets = new List<IdentityServer4.Models.Secret>{ new Secret("supersecret".Sha256()) }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
        {
            new ApiScope("openid"),
            new ApiScope("profile"),
            new ApiScope("email"),
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope("myApi.read"),
            new ApiScope("myApi.write")
            //new ApiScope("identity-server-demo-api")
        };
    }
}
