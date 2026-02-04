using Fylum.Application;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.PerformUpTo;

public record PerformMigrationsUpToCommand(Guid UpToMigrationId) : ICommand<IEnumerable<MigrationDto>>;