using Fylum.Client.Auth.Token.Storage;

namespace Fylum.Web.Services;

public interface IBrowserTokenStorage : ITokenStorage
{
    public Task LoadFromStorageAsync();
}
