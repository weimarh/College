using Domain.Asignaturas;
using Domain.Common;
using Domain.Primitives;

namespace Domain.Profesores;

public sealed class Maestro : AggregateRoot
{
    public Identifier Id { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Profesion { get; private set; } = null!;
    public List<AsignaturaACursar>? Asignaturas { get; private set; }

    public Maestro()
    {
    }

    public Maestro(
        Identifier id,
        string firstName,
        string lastName,
        string profesion,
        List<AsignaturaACursar>? asignaturas)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Profesion = profesion;
        Asignaturas = asignaturas;
    }
}