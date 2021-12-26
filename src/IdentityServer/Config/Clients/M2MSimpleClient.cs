using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer.Config.Clients
{
    public class M2MSimpleClient : Client
    {
        public M2MSimpleClient()
        {
            ClientId = "m2m-client";
            ClientSecrets = new List<Secret>() { new Secret("secret".Sha256()) };
            AllowedGrantTypes = GrantTypes.ClientCredentials;

            // scopes that client has access to
            AllowedScopes = new List<string>() { "api1" };
        }
    }
}