using Fylum.Domain.Files;
using Fylum.Postgres.Shared.Connection;
using File = Fylum.Domain.Files.File;

namespace Fylum.Postgres.Files;

internal class FileRepository : IFileRepository
{

    private readonly IOpenedConnectionProvider _openedConnectionProvider;

    public FileRepository(IOpenedConnectionProvider openedConnectionProvider)
    {
        _openedConnectionProvider = openedConnectionProvider;
    }

    public void Create(File file)
    {
        var connection = _openedConnectionProvider.GetOpenedConnection();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public File Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<File> GetAllInFolder(Guid folderId)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, File file)
    {
        throw new NotImplementedException();
    }
}