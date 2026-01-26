namespace Fylum.Folders.Domain.Tests;

[TestClass]
public class FolderTests
{
    [TestMethod]
    public void Create_WithProperties_AllPropertiesSet()
    {
        var expectedId = Guid.Parse("33A2D649-DEE3-4DF8-A9ED-EE70B42AF4D9");
        var expectedName = "My Folder";
        var expectedParentFolderId = Guid.Parse("A077A333-4956-4F79-A333-3B63A4DBDB2B");

        var folder = Folder.Create(expectedId, expectedParentFolderId, expectedName);

        Assert.AreEqual(expectedId, folder.Id);
        Assert.AreEqual(expectedName, folder.Name);
        Assert.AreEqual(expectedParentFolderId, folder.ParentFolderId);
    }

    [TestMethod]
    public void CreateNew_WithProperties_AllPropertiesSet()
    {
        var expectedName = "My Folder";
        var expectedParentFolderId = Guid.Parse("1A269705-4FC6-4B5A-8FBF-2ADFA59CC8A4");

        var folder = Folder.CreateNew(expectedParentFolderId, expectedName);

        Assert.AreEqual(expectedName, folder.Name);
        Assert.AreEqual(expectedParentFolderId, folder.ParentFolderId);
    }

    [TestMethod]
    public void Rename_WithKnownNewName_NameIsNewName()
    {
        var oldName = "old folder name";
        var parentFolderId = Guid.Parse("5FCE5B43-4DB5-4E11-88E0-9C1D0EF4DAF6");
        var folder = Folder.CreateNew(parentFolderId, oldName);

        var newName = "new folder name";
        folder.Rename(newName);

        Assert.AreEqual(newName, folder.Name);
    }

    [TestMethod]
    public void Move_WithKnownParentFolderId_ParentFolderIdIsChanged()
    {
        var name = "folder name";
        var oldParentFolderId = Guid.Parse("F21F4AD2-1238-448F-92E5-F36298B2694E");
        var folder = Folder.CreateNew(oldParentFolderId, name);

        var newParentFolderId = Guid.Parse("F7EA088A-0E89-431A-98DF-9C74A66FDB42");
        var newParentParentFolderId = Guid.Parse("C2759439-C317-4325-BF70-FDE218A95DF6");
        var newParentFolder = Folder.Create(newParentFolderId, newParentParentFolderId, "new parent");
        folder.Move(newParentFolder);

        Assert.AreEqual(newParentFolderId, folder.ParentFolderId);
    }
}
