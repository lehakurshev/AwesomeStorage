using NpgsqlTypes;

namespace Domain;

public class Element : IComparable<Element>
{
    Element(){}
    public Element(string details)
    {
        Id = Guid.NewGuid();
        Details = details;
        Created = DateTime.UtcNow;
        CountQueries = 0;
    }
    
    public Guid Id { get; set; }
    public string? Details { get; set; }
    public NpgsqlTsVector? DetailsSearch { get; set; }
    public DateTime Created { get; set; }
    public int CountQueries { get; set; }
    
    public int CompareTo(Element? other)
    {
        if (other == null) return 1;
        
        var createdDifference = (Created - other.Created).TotalHours;
        
        var countDifference = CountQueries - other.CountQueries;
        
        var combinedScore = 0.5 * createdDifference + 0.5 * countDifference;

        return combinedScore switch
        {
            < 0 => -1,
            > 0 => 1,
            _ => 0
        };
    }
}