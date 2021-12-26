using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer.Config.Clients
{
    public class InteractiveMvcClient : Client
    {
        public InteractiveMvcClient()
        {
            ClientId = "mvc";
            ClientSecrets = new List<Secret>() { new Secret("secret".Sha256()) };
            AllowedGrantTypes = GrantTypes.Code;

            // where to redirect to after login
            RedirectUris = new List<string>() { "https://localhost:5002/signin-oidc" };

            // where to redirect to after logout
            PostLogoutRedirectUris = new List<string>() { "https://localhost:5002/signout-callback-oidc" };

            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                "core.api"
            };
        }
    }
}

