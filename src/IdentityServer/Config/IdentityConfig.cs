// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using IdentityServer.Config.Clients;
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
                yield return new IdentityResources.Email();
                yield return new IdentityResources.Profile();
            }
        }

        public static IEnumerable<ApiScope> ApiScopes
        {
            get
            {
                yield return new ApiScope("core.api", "My API");
            }
        }

        public static IEnumerable<Client> Clients
        {
            get
            {
                yield return new WebBrowserStubClient();
                yield return new M2MSimpleClient();
                yield return new InteractiveMvcClient();
            }
        }
    }
}
