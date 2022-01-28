using MadWorld.Business.Models;

namespace MadWorld.API.Models;

public class MadWorldSettings
{
    public ApplicationUrls ApplicationUrls { get; set; }
    public AzureSettings AzureSettings { get; set; }
    public string BlobConnectionString { get; set; }
}