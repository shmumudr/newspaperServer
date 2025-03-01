

namespace indoxApi.Models
{

public class Indox
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<DemographicExposure> DemographicExposure { get; set; } = new List<DemographicExposure>();

    public int ActualExposure { get; set; }
    public int TotalPossibleExposure { get; set; } = 500000;
}

public class DemographicExposure
{
    public string Group { get; set; } = string.Empty; 
    public double Percentage { get; set; } 
}
}
