using Domain.Common;
using Domain.Notas;
using Domain.Primitives;

namespace Domain.Estudiantes;

public sealed class Alumno : AggregateRoot
{
    public Identifier Id { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public List<Nota>? Notas { get; private set; }

    public Alumno()
    {
    }

    public Alumno(
        Identifier id,
        string firstName,
        string lastName,
        List<Nota>? notas
    )
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Notas = notas;
    }
}
