using Domain.Notas;
using MediatR;

namespace Application.Estudiante.Create;

public record CreateEstudianteCommand(
    string FirstName,
    string LastName,
    List<Nota> Notas) : IRequest<Unit>;

