using Fylum.Core.Application.Command;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrations;

public record GetMigrationsCommand() : ICommand<IEnumerable<MigrationDto>>;