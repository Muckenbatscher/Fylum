namespace Fylum.Client.Auth.Token.Storage;

public class FileTokenStorage : ITokenStorage
{
    private readonly string _tokenStoreFilePath;

    public FileTokenStorage(string tokenStoreFilePath)
    {
        _tokenStoreFilePath = tokenStoreFilePath;
    }

    public async Task ClearTokenPair()
    {
        EnsureTokenStoreFileExists();
        await File.WriteAllLinesAsync(_tokenStoreFilePath, []);
    }
    public async Task<TokenPair?> GetTokenPairAsync()
    {
        EnsureTokenStoreFileExists();
        var lines = await File.ReadAllLinesAsync(_tokenStoreFilePath);
        if (lines.Length != 2)
            return null;

        var accessToken = lines[0];
        var refreshToken = lines[1];
        return new TokenPair(accessToken, refreshToken);
    }
    public async Task StoreTokenPairAsync(TokenPair tokenPair)
    {
        EnsureTokenStoreFileExists();
        IEnumerable<string> lines = [tokenPair.AccessToken, tokenPair.RefreshToken];
        await File.WriteAllLinesAsync(_tokenStoreFilePath, lines);
    }

    private void EnsureTokenStoreFileExists()
    {
        if (!File.Exists(_tokenStoreFilePath))
            File.Create(_tokenStoreFilePath).Dispose();
    }
}
