namespace API.Request;

public class MaintenanceRequest
{
    public string productSerialNumber { get; set; }
    
    public string summary { get; set; }
    public string description { get; set; }
    public int activityResult { get; set; }
}