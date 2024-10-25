using System;
using Domain.Common;
using Domain.Materias;
using Domain.Notas;
using Domain.Primitives;
using Domain.Profesores;

namespace Domain.Asignaturas;

public sealed class AsignaturaACursar : AggregateRoot
{
    public Identifier Id { get; private set; } = null!;
    public MateriaACursar Materia { get; private set; } = null!;
    public Maestro Profesor { get; private set; } = null!;
    public string? Horario { get; private set; }
    public string Curricula { get; private set; } = null!;
    public List<Nota>? Notas { get; private set; }

    public AsignaturaACursar()
    {
    }

    public AsignaturaACursar(
        Identifier id,
        MateriaACursar materia,
        Maestro profesor,
        string horario,
        string curricula,
        List<Nota> notas
    )
    {
        Id = id;
        Materia = materia;
        Profesor = profesor;
        Horario = horario;
        Curricula = curricula;
        Notas = notas;
    }
}
