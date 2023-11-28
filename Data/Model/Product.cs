using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Product : Base
{
    public string brand { get; set; }
    public string model { get; set; }
    public string serialNumber { get; set; }
    public int status { get; set; }
    
    public string statusDescription { get; set; }
    
    public MaintenanceActivity activity { get; set; }
}