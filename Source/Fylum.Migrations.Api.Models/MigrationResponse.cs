namespace Fylum.Migrations.Api.Models;

public record MigrationResponse : MigrationDto
{
    public MigrationResponse(MigrationDto original) : base(original)
    {
    }
}