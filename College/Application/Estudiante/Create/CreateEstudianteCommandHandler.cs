using Domain.Common;
using Domain.Estudiantes;
using Domain.Primitives;
using MediatR;

namespace Application.Estudiante.Create;

public sealed class CreateEstudianteCommandHandler : IRequestHandler<CreateEstudianteCommand, Unit>
{
    private readonly IEstudianteReposiroty _estudianteReposiroty;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEstudianteCommandHandler(
        IEstudianteReposiroty estudianteReposiroty,
        IUnitOfWork unitOfWork)
    {
        _estudianteReposiroty = estudianteReposiroty ??
            throw new ArgumentNullException(nameof(estudianteReposiroty));
        _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateEstudianteCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.FirstName) ||
            string.IsNullOrWhiteSpace(command.LastName))
        {
            throw new ArgumentException("First name and last name are required.");
        }

        var estudiante = new Alumno(
            new Identifier(Guid.NewGuid()),
            command.FirstName,
            command.LastName,
            command.Notas);

        _estudianteReposiroty.AddAsync(estudiante);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
