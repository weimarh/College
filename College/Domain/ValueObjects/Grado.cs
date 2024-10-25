namespace Domain.ValueObjects;

public partial record Grado
{
    public Grado(string nivel, string curso)
    {
        Curso = curso;
        Nivel = nivel;
    }

    public string Curso { get; set; }
    public string Nivel { get; set; }

    public static Grado? Create(string nivel, string curso)
    {
        if (string.IsNullOrWhiteSpace(nivel) || string.IsNullOrWhiteSpace(curso))
            return null;

        return new Grado(nivel, curso);
    }
}
