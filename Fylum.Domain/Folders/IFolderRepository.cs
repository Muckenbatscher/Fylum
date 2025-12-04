namespace Fylum.Domain.Folders;

public interface IFolderRepository
{
    Folder Get(Guid id);
    IEnumerable<Folder> GetAllInFolder(Guid folderId);
    void Create(Folder folder);
    void Delete(Guid id);
    void Update(Guid id, Folder folder);
}