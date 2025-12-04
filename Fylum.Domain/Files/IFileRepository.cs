namespace Fylum.Domain.Files;

public interface IFileRepository
{
    File Get(Guid id);
    IEnumerable<File> GetAllInFolder(Guid folderId);
    void Create(File file);
    void Delete(Guid id);
    void Update(Guid id, File file);
}