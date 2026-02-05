using Fylum.Core.Application.Query;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrations;

public record GetMigrationsQuery() : IQuery<IEnumerable<MigrationDto>>;