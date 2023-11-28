using Data.Model;

namespace Data.Interfaces;

public interface IMaintenanceData
{
    public bool create(MaintenanceActivity maintenanceActivity);
}