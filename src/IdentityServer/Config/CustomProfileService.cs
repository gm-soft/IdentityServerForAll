using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Config;

public class CustomProfileService : IProfileService
{
    private readonly ILogger<CustomProfileService> _logger;

    public CustomProfileService(ILogger<CustomProfileService> logger)
    {
        _logger = logger;
    }

    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        _logger.LogDebug("GetProfileDataAsync called from: {Caller}", context.Caller);
        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}