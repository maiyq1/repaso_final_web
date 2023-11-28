using Data;
using Data.Model;

namespace Domain;

public class MaintenanceActivityDomain : IMaintenanceActivityDomain
{
    public IMaintenanceData _MaintenanceData;

    public MaintenanceActivityDomain(IMaintenanceData maintenanceData)
    {
        _MaintenanceData = maintenanceData;
    }
    
    public bool create(MaintenanceActivity activity)
    {
        if (_MaintenanceData.GetDbContext().Products.Any(item => item.serialNumber == activity.productSerialNumber))
        {
            return _MaintenanceData.create(activity);
        }
        else
        {
            return false;
        }
    }
}