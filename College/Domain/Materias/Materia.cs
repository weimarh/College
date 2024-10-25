using Domain.Asignaturas;
using Domain.Common;
using Domain.Primitives;

namespace Domain.Materias;

public sealed class MateriaACursar : AggregateRoot
{
    public Identifier Id { get; private set; } = null!;
    public string Nombre { get; private set; } = null!;
    public List<AsignaturaACursar>? Asignaturas { get; private set; }

    public MateriaACursar()
    {
    }

    public MateriaACursar(
        Identifier id,
        string nombre,
        List<AsignaturaACursar>? asignaturas)
    {
        Id = id;
        Nombre = nombre;
        Asignaturas = asignaturas;
    }
}
