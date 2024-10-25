using Domain.Common;
using Domain.Materias;
using Domain.Primitives;
using MediatR;

namespace Application.Materia.Create;

public sealed class CreateMateriaCommandHandler : IRequestHandler<CreateMateriaCommand, Unit>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateMateriaCommandHandler(
        IMateriaRepository materiaRepository,
        IUnitOfWork unitOfWork)
    {
        _materiaRepository = materiaRepository ??
            throw new ArgumentNullException(nameof(materiaRepository));
        _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateMateriaCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.Nombre))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(command.Nombre));
        }

        var materia = new MateriaACursar(
            new Identifier(Guid.NewGuid()),
            command.Nombre,
            command.Asignaturas
        );

        _materiaRepository.AddAsync(materia);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
