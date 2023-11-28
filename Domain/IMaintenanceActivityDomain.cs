using Data.Model;

namespace Domain;

public interface IMaintenanceActivityDomain
{
    public bool create(MaintenanceActivity activity);
}