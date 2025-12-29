using Fylum.Client.Auth.Token;
using Fylum.EndToEnd.DistributedApplicationBuilding;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.EndToEnd.ClientApplicationBuilding;

internal class ClientApplication : IDisposable, IAsyncDisposable
{
    private readonly DistributedApplicationContainer _distributedApp;
    private readonly IServiceProvider _serviceProvider;

    public ClientApplication(DistributedApplicationContainer distributedApp,
        IServiceProvider serviceProvider)
    {
        _distributedApp = distributedApp;
        _serviceProvider = serviceProvider;
    }

    public T GetService<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }
    public async Task AdminLogin() => await AdminLogin(CancellationToken.None);
    public async Task AdminLogin(CancellationToken cancellationToken)
    {
        const string seedAdminUsername = "admin";
        const string seedAdminPassword = "admin";
        var tokenService = GetService<ITokenService>();
        await tokenService.LoginAsync(seedAdminUsername, seedAdminPassword, cancellationToken);
    }

    public void Dispose()
       => _distributedApp.Dispose();
    public async ValueTask DisposeAsync()
        => await _distributedApp.DisposeAsync();
}
