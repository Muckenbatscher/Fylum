using Fylum.Client;
using Fylum.Client.Auth.Token;
using Fylum.Client.Folders;
using Fylum.EndToEnd.ApplicationBuilding;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.EndToEnd;

[TestClass]
public sealed class FolderTests
{
    private static DistributedApplicationContainer? _app;

    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static async Task ClassInit(TestContext context)
    {
        _app = await DistributedApplicationContainerFactory.CreateAsync(context.CancellationToken,
            migrate: true, persistent: false);
    }
    [ClassCleanup]
    public static async Task ClassCleanup()
    {
        if (_app != null)
            await _app.DisposeAsync();
    }

    [TestMethod]
    public async Task GetRootFolder_ReturnsExistingRootFolder()
    {
        var apiBaseUri = _app?.GetApiBaseUri();
        if (apiBaseUri == null)
            throw new Exception("Api is not initialized");

        var clientServices = new ServiceCollection();
        clientServices.AddFylumClients(options =>
        {
            options.BaseUri = apiBaseUri;
            options.Timeout = TimeSpan.FromSeconds(5);
        });
        var clientProvider = clientServices.BuildServiceProvider();
        var folderClient = clientProvider.GetRequiredService<IFolderClient>();
        var tokenService = clientProvider.GetRequiredService<ITokenService>();
        await tokenService.LoginAsync("admin", "admin", TestContext.CancellationToken);

        var rootFolder = await folderClient.GetRootFolderAsync(TestContext.CancellationToken);

        Assert.AreEqual("root", rootFolder.Name);
        Assert.AreEqual(Guid.Empty, rootFolder.ParentFolderId);
    }
}
