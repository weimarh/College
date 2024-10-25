using Domain.Asignaturas;
using Domain.Estudiantes;
using Domain.Materias;
using Domain.Notas;
using Domain.Profesores;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Maestro> Profesores { get; set; }
    DbSet<Alumno> Estudiantes { get; set; }
    DbSet<MateriaACursar> Materias { get; set; }
    DbSet<Nota> Notas { get; set; }
    DbSet<AsignaturaACursar> Asignaturas { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
