using Fylum.Core.Application.Query;
using Fylum.Folders.Api.Common.Application;

namespace Fylum.Folders.Api.Features.GetChildFolders;

public record GetChildFoldersQuery(Guid ParentFolderId) : IQuery<IList<FolderDto>>;