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
    public Folder? GetById(Guid id)
    {
        var param = new { Id = id };
        var sql = @$"SELECT id as '{nameof(FolderQueryModel.Id)}', 
                            parent_folder_id as '{nameof(FolderQueryModel.ParentFolderId)}', 
                            name as '{nameof(FolderQueryModel.Name)}'
                     FROM folders
                     WHERE id = @{nameof(param.Id)};";
        var transaction = _transactionFactory.GetTransaction();
        var queryResult = transaction.Connection.QuerySingleOrDefault<FolderQueryModel>(
            sql, param, transaction.Transaction);
        return queryResult == null
            ? null
            : GetFromQueryModel(queryResult);
    }
    public IEnumerable<Folder> GetChildFolders(Guid parentFolderId)
    {
        var param = new { ParentFolderId = parentFolderId };
        var sql = @$"SELECT id as '{nameof(FolderQueryModel.Id)}', 
                            parent_folder_id as '{nameof(FolderQueryModel.ParentFolderId)}', 
                            name as '{nameof(FolderQueryModel.Name)}'
                     FROM folders
                     WHERE parent_folder_id = @{nameof(param.ParentFolderId)};";
        var transaction = _transactionFactory.GetTransaction();
        var result = transaction.Connection.Query<FolderQueryModel>(sql, param, transaction.Transaction);
        return result.Select(GetFromQueryModel).ToList();
    }
    public void Update(Folder folder)
    {
        var param = new
        {
            folder.Id,
            folder.ParentFolderId,
            folder.Name
        };
        var sql = @$"UPDATE folders
                     SET parent_folder_id = @{nameof(FolderQueryModel.ParentFolderId)}, 
                         name = @{nameof(param.Name)}
                     WHERE id = @{nameof(param.Id)};";
        var transaction = _transactionFactory.GetTransaction();
        transaction.Connection.Execute(sql, param, transaction.Transaction);
    }

    private Folder GetFromQueryModel(FolderQueryModel model)
        => Folder.Create(model.Id, model.ParentFolderId, model.Name);
}
