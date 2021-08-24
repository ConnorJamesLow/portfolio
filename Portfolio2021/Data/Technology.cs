
namespace Portfolio2021.Data;
public record Technology
{
    public string Key { get; init; } = "";
    public bool Featured { get; init; }
    public string Category { get; init; } = "";
    public string Proficiency { get; init; } = "";
    public int Since { get; init; }
    public string Title { get; init; } = "";
    public int Years { get; init; }
}

public static class Proficiencies
{
    public const string FLUENT = "fluent";
    public const string CONVERSATIONAL = "conversational";
    public const string ACADEMIC = "academic";
}