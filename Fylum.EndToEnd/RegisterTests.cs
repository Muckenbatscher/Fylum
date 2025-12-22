using Aspire.Hosting;
using Aspire.Hosting.Testing;
using Fylum.Client.Auth;
using Fylum.Users.Api.Shared;

namespace Fylum.EndToEnd;

[TestClass]
public sealed class RegisterTests
{
    private static IDistributedApplicationTestingBuilder? _appHost;
    private static DistributedApplication? _app;
    private static HttpClient? _httpClient;

    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static async Task ClassInit(TestContext context)
    {
        _appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.Fylum_AppHost>(["NonPersistent=true"], context.CancellationToken);

        _app = await _appHost.BuildAsync(context.CancellationToken);
        await _app.StartAsync(context.CancellationToken);

        var migrateResult = await _app.ResourceCommands.ExecuteCommandAsync("migrations-api", "perform-all", context.CancellationToken);
        if (migrateResult == null || !migrateResult.Success)
            throw new Exception("Could not perform the migrations to the temporary database");

        _httpClient = _app.CreateHttpClient("api");
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
        if (_httpClient == null)
            throw new Exception("HttpClient is not initialized");

        var authClient = new AuthClient(_httpClient);

        const string testUsername = "test-username";
        const string testPassword = "test-password";

        var registerRequest = new RegisterRequest(testUsername, testPassword);
        await authClient.RegisterAsync(registerRequest, TestContext.CancellationToken);

        var loginRequest = new LoginRequest(testUsername, testPassword);
        var loginResult = await authClient.LoginAsync(loginRequest, TestContext.CancellationToken);

        Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.AccessToken));
        Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.RefreshToken));
    }
}
