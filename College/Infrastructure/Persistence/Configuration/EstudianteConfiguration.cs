using Domain.Common;
using Domain.Estudiantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class EstudianteConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            Identifier => Identifier.Value,
            value => new Identifier(value)
        );

        builder.Property(e => e.FirstName).HasMaxLength(20);

        builder.Property(e => e.LastName).HasMaxLength(20);

        //builder.HasMany(e => e.Notas).WithOne(x => x.)
    }
}
