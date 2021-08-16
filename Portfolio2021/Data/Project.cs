namespace Portfolio2021.Data;

public record Project
{
    public string Key { get; init; } = "";
    public string Colors { get; init; } = "indigo";
    public DateRange? Dates { get; init; }
    public string? Description { get; init; }
    public bool Featured { get; init; }
    public string[] Highlights { get; init; } = Array.Empty<string>();
    public string? Link { get; init; }
    public string? Role { get; init; }
    public string[] Stack { get; init; } = Array.Empty<string>();
    public string? Summary { get; init; }
    public string Title { get; init; } = "";
}

