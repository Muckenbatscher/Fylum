using Fylum.Core.Application.Query;
using Fylum.Folders.Api.Common.Application;

namespace Fylum.Folders.Api.Features.GetFolderById;

public record GetFolderByIdQuery(Guid FolderId) : IQuery<FolderDto>;
