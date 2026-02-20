using Fylum.Core.Application.Query;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetRootFolder;

public record GetRootFolderQuery : IQuery<FolderDto>;
