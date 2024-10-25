using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial record Puntaje
{
    private const string Pattern = @"^\d+(\.\d{1,2})?$";

    private Puntaje(string value) => Value = value;

    public static Puntaje? Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !PuntajeRegex().IsMatch(value))
        {
            return null;
        }

        return new Puntaje(value);
    }

    public string Value { get; init; } = "0";

    [GeneratedRegex(Pattern)]
    private static partial Regex PuntajeRegex();
}
