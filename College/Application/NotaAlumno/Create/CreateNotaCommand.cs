using Domain.Asignaturas;
using Domain.Estudiantes;
using MediatR;

namespace Application.NotaAlumno.Create;

public record CreateNotaCommand(
    Alumno Estudiante,
    AsignaturaACursar Asignatura,
    string PuntajePrimerTrimestre,
    string PuntajeSegundoTrimestre,
    string PuntajeTercerTrimestre) : IRequest<Unit>;