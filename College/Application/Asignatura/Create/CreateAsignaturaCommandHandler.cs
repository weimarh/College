using Domain.Asignaturas;
using Domain.Common;
using Domain.Primitives;
using MediatR;

namespace Application.Asignatura.Create;

public sealed class CreateAsignaturaCommandHandler : IRequestHandler<CreateAsignaturaCommand, Unit>
{
    private readonly IAsignaturaRepository _asignaturaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAsignaturaCommandHandler(
        IUnitOfWork unitOfWork,
        IAsignaturaRepository asignaturaRepository)
    {
        _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
        _asignaturaRepository = asignaturaRepository ??
            throw new ArgumentNullException(nameof(asignaturaRepository));
    }

    public async Task<Unit> Handle(CreateAsignaturaCommand command, CancellationToken cancellationToken)
    {
        if (command.Materia is null ||
            command.Profesor is null ||
            string.IsNullOrWhiteSpace(command.Horario) ||
            string.IsNullOrWhiteSpace(command.Curricula))
        {
            throw new ArgumentException("Los campos no pueden estar vacíos");
        }

        var asignatura = new AsignaturaACursar(
            new Identifier(Guid.NewGuid()),
            command.Materia,
            command.Profesor,
            command.Horario,
            command.Curricula,
            command.Notas
        );

        _asignaturaRepository.AddAsync(asignatura);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
