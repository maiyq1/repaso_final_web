using Data.DBContext;
using Data.Interfaces;
using Data.Model;

namespace Data;

public class MaintenanceData : IMaintenanceData
{
    private IsaDBContext _isaDbContext;

    public MaintenanceData(IsaDBContext isaDbContext)
    {
        _isaDbContext = isaDbContext;
    }
    
    public bool create(MaintenanceActivity maintenanceActivity)
    {
        try
        {
            _isaDbContext.MaintenanceActivities.Add(maintenanceActivity);
            _isaDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}