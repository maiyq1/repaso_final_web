using Data.DBContext;
using Data.Model;

namespace Data;

public interface IMaintenanceData
{
    public bool create(MaintenanceActivity activity);
    public IsaDBContext GetDbContext();
}