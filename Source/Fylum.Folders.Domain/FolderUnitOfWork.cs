using Fylum.Domain.UnitOfWork;

namespace Fylum.Folders.Domain;

public class FolderUnitOfWork : UnitOfWork
{
    public FolderUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory,
        IFolderRepository folderRepository) : base(transactionFactory)
    {
        FolderRepository = folderRepository;
    }

    public IFolderRepository FolderRepository { get; }
}
