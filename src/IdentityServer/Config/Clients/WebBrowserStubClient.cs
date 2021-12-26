using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer.Config.Clients
{
    public class WebBrowserStubClient : Client
    {
        public WebBrowserStubClient()
        {
            ClientId = "client";
            ClientSecrets = new List<Secret>()
            {
                new Secret("secret".Sha256())
            };
            AllowedGrantTypes = new List<string>()
            {
                GrantType.Implicit,
            };

            // scopes that client has access to
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                "core.api"
            };

            RedirectUris = new List<string>()
            {
                "https://oauthdebugger.com/debug"
            };

            AllowAccessTokensViaBrowser = true;
            AlwaysSendClientClaims = true;
            AlwaysIncludeUserClaimsInIdToken = true;
        }
    }
}