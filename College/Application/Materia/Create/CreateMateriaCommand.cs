using Domain.Asignaturas;
using MediatR;

namespace Application.Materia.Create;

public record CreateMateriaCommand(
    string Nombre,
    List<AsignaturaACursar> Asignaturas) : IRequest<Unit>;