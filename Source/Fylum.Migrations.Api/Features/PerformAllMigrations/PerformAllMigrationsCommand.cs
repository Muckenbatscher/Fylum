using Fylum.Core.Application.Command;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.PerformAllMigrations;

public record PerformAllMigrationsCommand : ICommand<IEnumerable<MigrationDto>>;