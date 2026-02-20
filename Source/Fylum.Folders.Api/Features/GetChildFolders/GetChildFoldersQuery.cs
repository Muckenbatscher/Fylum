using Fylum.Core.Application.Query;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetChildFolders;

public record GetChildFoldersQuery(Guid ParentFolderId) : IQuery<IList<FolderDto>>;