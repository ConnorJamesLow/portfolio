namespace Portfolio2021.Data;

public record DateRange
{
    public string? From { get; init; }
    public bool? Ongoing { get; init; }
    public string? To { get; init; }
}

public static class DateRangeExtensions
{
    public static DateOnly GetFromDate(this DateRange range) => DateOnly.Parse(range.From ?? throw new NullReferenceException(nameof(DateRange.From)));
    public static DateOnly GetToDate(this DateRange range) => DateOnly.Parse(range.To ?? throw new NullReferenceException(nameof(DateRange.To)));
    public static string ToSimpleDate(this DateRange range)
    {
        if (range.From is null)
        {
            return $"{range.GetToDate():yyyy}";
        }
        DateOnly from = range.GetFromDate();
        if (range.Ongoing is true)
        {
            return $"{range.GetFromDate():yyyy} - now";
        }
        if (range.To is null)
        {
            return from.Year.ToString();
        }
        DateOnly to = range.GetToDate();
        return from.Year == to.Year ? from.Year.ToString() : $"{range.GetFromDate():yyyy} - {range.GetToDate():yyyy}";
    }
}
