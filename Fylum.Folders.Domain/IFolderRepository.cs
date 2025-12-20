namespace Fylum.Folders.Domain;

public interface IFolderRepository
{
    void Add(Folder folder);
    void Update(Folder folder);
    Folder? GetById(Guid id);
    IEnumerable<Folder> GetChildFolders(Guid parentFolderId);
}
