using Fylum.Application;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public record GetMigrationByIdCommand(Guid MigrationId) : ICommand<MigrationDto>;