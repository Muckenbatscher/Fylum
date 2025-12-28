using Fylum.Client.Auth;
using Fylum.EndToEnd.ApplicationBuilding;
using Fylum.Users.Api.Shared;

namespace Fylum.EndToEnd;

[TestClass]
public sealed class UsersTests
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
    public async Task Register_ThenLogin_ReturnsAccessTokenAndRefreshToken()
    {
        var httpClient = _app?.CreateApiHttpClient();
        if (httpClient == null)
            throw new Exception("HttpClient is not initialized");

        var authClient = new AuthClient(httpClient);

        const string testUsername = "test-username";
        const string testPassword = "test-password";

        var registerRequest = new RegisterRequest(testUsername, testPassword);
        await authClient.RegisterAsync(registerRequest, TestContext.CancellationToken);

        var loginRequest = new LoginRequest(testUsername, testPassword);
        var loginResult = await authClient.LoginAsync(loginRequest, TestContext.CancellationToken);

        Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.AccessToken));
        Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.RefreshToken));
    }

    [TestMethod]
    public async Task LoginAsSeededAdmin_ReturnsAccessTokenAndRefreshToken()
    {
        var httpClient = _app?.CreateApiHttpClient();
        if (httpClient == null)
            throw new Exception("HttpClient is not initialized");

        var authClient = new AuthClient(httpClient);

        const string seedAdminUsername = "admin";
        const string seedAdminPassword = "admin";

        var loginRequest = new LoginRequest(seedAdminUsername, seedAdminPassword);
        var loginResult = await authClient.LoginAsync(loginRequest, TestContext.CancellationToken);

        Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.AccessToken));
        Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.RefreshToken));
    }
}
