namespace MadWorld.API.Models;

public class DataBaseSettings
{
    public StartupSettings StartupSettings { get; set; }
    public string ConnectionString { get; set; }
    public bool IsDevelopment { get; set; }
    public bool IsProduction { get; set; }
}