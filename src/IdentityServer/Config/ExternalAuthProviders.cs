using System;
using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Config
{
    public static class ExternalAuthProviders
    {
        public static IServiceCollection Google(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("External").GetSection("Google");
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = section["ClientId"]
                                       ?? throw new ArgumentNullException(paramName: "Google:ClientId");

                    options.ClientSecret = section["ClientSecret"]
                                           ?? throw new ArgumentNullException(paramName: "Google:ClientSecret");
                });

            return services;
        }

        public static IServiceCollection Facebook(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("External").GetSection("Facebook");
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = section["ClientId"]
                                       ?? throw new ArgumentNullException(paramName: "Facebook:ClientId");

                    options.ClientSecret = section["ClientSecret"]
                                           ?? throw new ArgumentNullException(paramName: "Facebook:ClientSecret");
                });

            return services;
        }
    }
}