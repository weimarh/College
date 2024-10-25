using Domain.Asignaturas;
using Domain.Common;
using Domain.Estudiantes;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Notas;

public sealed class Nota : AggregateRoot
{
    public Identifier Id { get; private set; } = null!;
    public Identifier EstudianteId { get; set; } = null!;
    public Alumno Estudiante { get; private set; } = null!;
    public Identifier AsignaturaId { get; set; } = null!;
    public AsignaturaACursar Asignatura { get; private set; } = null!;
    public Puntaje PuntajePrimerTrimestre { get; private set; } = null!;
    public Puntaje PuntajeSegundoTrimestre { get; private set; } = null!;
    public Puntaje PuntajeTercerTrimestre { get; private set; } = null!;

    public int Promedio()
    {
        try
        {
            return Int32.Parse(PuntajePrimerTrimestre.Value) +
                Int32.Parse(PuntajeSegundoTrimestre.Value) +
                Int32.Parse(PuntajeTercerTrimestre.Value);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public bool Aprobado()
    {
        return Promedio() >= 51;
    }

    public Nota(
        Identifier id,
        Identifier estudianteId,
        Alumno estudiante,
        Identifier asignaturaId,
        AsignaturaACursar asignatura,
        Puntaje puntajePrimerTrimestre,
        Puntaje puntajeSegundoTrimestre,
        Puntaje puntajeTercerTrimestre)
    {
        Id = id;
        EstudianteId = estudianteId;
        Estudiante = estudiante;
        AsignaturaId = asignaturaId;
        Asignatura = asignatura;
        PuntajePrimerTrimestre = puntajePrimerTrimestre;
        PuntajeSegundoTrimestre = puntajeSegundoTrimestre;
        PuntajeTercerTrimestre = puntajeTercerTrimestre;
    }

    public Nota()
    {
    }
}
