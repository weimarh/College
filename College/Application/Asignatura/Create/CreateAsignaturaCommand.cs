using Domain.Materias;
using Domain.Notas;
using Domain.Profesores;
using MediatR;

namespace Application.Asignatura.Create;

public record CreateAsignaturaCommand(
    MateriaACursar Materia,
    Maestro Profesor,
    string Horario,
    string Curricula,
    List<Nota> Notas) : IRequest<Unit>;