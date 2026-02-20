using Fylum.Core.Application.Query;
using Fylum.Folders.SharedModels;

namespace Fylum.Folders.Api.Features.GetFolderById;

public interface IGetFolderByIdQueryHandler : IQueryHandler<GetFolderByIdQuery, FolderDto>
{
}
