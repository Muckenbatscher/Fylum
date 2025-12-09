using Fylum.Shared.Files;

namespace Fylum.Client;

public interface IFylumClient
{
    Task<FileResponse> GetById(Guid id, CancellationToken cancellationToken);
}
