using Fylum.Domain;

namespace Fylum.Folders.Domain;

public class Folder : IdentifiableEntity<Guid>
{
    public Guid ParentFolderId { get; private set; }
    public string Name { get; private set; }

    private Folder(Guid id, Guid parentFolderId, string name) : base(id)
    {
        ParentFolderId = parentFolderId;
        Name = name;
    }
    public static Folder Create(Guid id, Guid parentFolderId, string name)
        => new(id, parentFolderId, name);

    public static Folder CreateNew(Guid parentFolderId, string name)
        => new(Guid.NewGuid(), parentFolderId, name);

    public void Rename(string newName)
    {
        Name = newName;
    }

    public void Move(Folder newParentFolder)
    {
        ParentFolderId = newParentFolder.Id;
    }
}
