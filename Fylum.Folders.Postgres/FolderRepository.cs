using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Folders.Domain;

namespace Fylum.Folders.Postgres;

public class FolderRepository : IFolderRepository
{
    private readonly IUnitOfWorkTransactionFactory _transactionFactory;

    public FolderRepository(IUnitOfWorkTransactionFactory transactionFactory)
    {
        _transactionFactory = transactionFactory;
    }

    public void Add(Folder folder)
    {
        var param = new
        {
            folder.Id,
            folder.ParentFolderId,
            folder.Name
        };
        var sql = @$"INSERT INTO folders (id, parent_folder_id, name)
                     VALUES (@{nameof(param.Id)}, @{nameof(param.ParentFolderId)}, @{nameof(param.Name)});";
        var transaction = _transactionFactory.GetTransaction();
        transaction.Connection.Execute(sql, param, transaction.Transaction);
    }
    public Folder? GetById(Guid id) => throw new NotImplementedException();
    public IEnumerable<Folder> GetChildFolders(Guid parentFolderId) => throw new NotImplementedException();
    public void Update(Folder folder) => throw new NotImplementedException();
}
