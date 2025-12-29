using Fylum.Client.Folders;
using Fylum.EndToEnd.ClientApplicationBuilding;

namespace Fylum.EndToEnd;

[TestClass]
public sealed class FolderTests
{
    private static ClientApplication? _app;

    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static async Task ClassInit(TestContext context)
    {
        _app = await ClientApplicationFactory.CreateAsync(context.CancellationToken);
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
        if (_app == null)
            throw new Exception("Client application is not initialized");

        await _app.AdminLogin(TestContext.CancellationToken);
        var folderClient = _app.GetService<IFolderClient>();

        var rootFolder = await folderClient.GetRootFolderAsync(TestContext.CancellationToken);

        Assert.AreEqual("root", rootFolder.Name);
        Assert.AreEqual(Guid.Empty, rootFolder.ParentFolderId);
    }
}
