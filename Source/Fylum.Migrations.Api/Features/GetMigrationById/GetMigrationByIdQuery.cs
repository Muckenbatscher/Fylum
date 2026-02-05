using Fylum.Core.Application.Query;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public record GetMigrationByIdQuery(Guid MigrationId) : IQuery<MigrationDto>;