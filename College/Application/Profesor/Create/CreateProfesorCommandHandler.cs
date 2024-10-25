using Domain.Asignaturas;
using Domain.Common;
using Domain.Primitives;
using Domain.Profesores;
using MediatR;

namespace Application.Profesor.Create;

public sealed class CreateProfesorCommandHandler : IRequestHandler<CreateProfesorCommand, Unit>
{
    private readonly IProfesorRepository _profesorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProfesorCommandHandler(
        IProfesorRepository profesorRepository,
        IUnitOfWork unitOfWork)
    {
        _profesorRepository = profesorRepository ??
            throw new ArgumentNullException(nameof(profesorRepository));
        _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateProfesorCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.FirstName) ||
            string.IsNullOrWhiteSpace(command.LastName) ||
            string.IsNullOrWhiteSpace(command.Profesion))
        {
            throw new ArgumentException("First name, last name, and email are required.");
        }

        var nuevoProfesor = new Maestro(
            new Identifier(Guid.NewGuid()),
            command.FirstName,
            command.LastName,
            command.Profesion,
            command.Asignaturas);

        _profesorRepository.AddAsync(nuevoProfesor);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
