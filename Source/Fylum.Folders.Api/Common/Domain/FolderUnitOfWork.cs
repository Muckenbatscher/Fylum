using Fylum.Core.Domain;

namespace Fylum.Folders.Api.Common.Domain;

public class FolderUnitOfWork : UnitOfWork
{
    public FolderUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IFolderRepository folderRepository) : base(transactionFactory)
    {
        FolderRepository = folderRepository;
    }

    public IFolderRepository FolderRepository { get; }
}
