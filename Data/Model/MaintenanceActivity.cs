using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Model;

public class MaintenanceActivity : Base
{
    public string productSerialNumber { get; set; }
    
    public string summary { get; set; }
    public string description { get; set; }
    public int activityResult { get; set; }
    
    public Product product { get; set; }
}