using Domain.Common;
using Domain.Estudiantes;
using Domain.Notas;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;

namespace Application.NotaAlumno.Create;

public sealed class CreateNotaCommandHandler : IRequestHandler<CreateNotaCommand, Unit>
{
    private readonly INotaRepository _notaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotaCommandHandler(
        IUnitOfWork unitOfWork,
        INotaRepository notaRepository)
    {
        _unitOfWork = unitOfWork;
        _notaRepository = notaRepository;
    }

    public Task<Unit> Handle(CreateNotaCommand command, CancellationToken cancellationToken)
    {
        if (Puntaje.Create(command.PuntajePrimerTrimestre) is not Puntaje primerPuntaje ||
            Puntaje.Create(command.PuntajeSegundoTrimestre) is not Puntaje segundoPuntaje ||
            Puntaje.Create(command.PuntajeTercerTrimestre) is not Puntaje tercerPuntaje ||
            command.Estudiante == null ||
            command.Asignatura == null)
        {
            throw new Exception("Error al crear la nota");
        }

        var nota = new Nota(
            new Identifier(Guid.NewGuid()),
            command.Estudiante,
            command.Asignatura,
            primerPuntaje,
            segundoPuntaje,
            tercerPuntaje
        );

        _notaRepository.AddAsync(nota);

        _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Task;
    }
}
