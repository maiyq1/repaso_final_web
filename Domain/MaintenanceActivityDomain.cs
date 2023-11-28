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
        //if(true)
        {
            
            switch (activity.activityResult)
            {
                case 0:
                    if (_MaintenanceData.getBySerialNumber(activity.productSerialNumber).status == 1)
                    {
                        _MaintenanceData.getBySerialNumber(activity.productSerialNumber).status = 2;
                        _MaintenanceData.getBySerialNumber(activity.productSerialNumber).statusDescription = "UNOPERATIONAL";
                    }
                    break;
                
                case 1:
                    if (_MaintenanceData.getBySerialNumber(activity.productSerialNumber).status == 2)
                    {
                        _MaintenanceData.getBySerialNumber(activity.productSerialNumber).status = 1;
                        _MaintenanceData.getBySerialNumber(activity.productSerialNumber).statusDescription = "OPERATIONAL";
                    }
                    break;
            }
            
            //_MaintenanceData.getBySerialNumber(activity.productSerialNumber)
            
            return _MaintenanceData.create(activity);
        }
        else
        {
            return false;
        }
    }
}