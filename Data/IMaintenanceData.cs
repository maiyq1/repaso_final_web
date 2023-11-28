using Data.Model;

namespace Data;

public interface IMaintenanceData
{
    public bool create(MaintenanceActivity activity);
}