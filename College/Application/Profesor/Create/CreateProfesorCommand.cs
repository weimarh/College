using Domain.Asignaturas;
using MediatR;

namespace Application.Profesor.Create;

public record CreateProfesorCommand(
    string FirstName,
    string LastName,
    string Profesion,
    List<AsignaturaACursar>? Asignaturas) : IRequest<Unit>;