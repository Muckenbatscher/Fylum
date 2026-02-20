namespace Fylum.Folders.Api.Common.Infrastructure;

internal class FolderQueryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ParentFolderId { get; set; }
}
