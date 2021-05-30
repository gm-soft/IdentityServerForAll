// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer.Config
{
    public static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources
        {
            get
            {
                yield return new IdentityResources.OpenId();
                yield return new IdentityResources.Profile();
            }
        }

        public static IEnumerable<ApiScope> ApiScopes
        {
            get
            {
                yield return new ApiScope("api1", "My API");
            }
        }

        public static IEnumerable<Client> Clients
        {
            get
            {
                // machine to machine client
                yield return new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                };

                // interactive ASP.NET Core MVC client
                yield return new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                };
            }
        }
    }
}
