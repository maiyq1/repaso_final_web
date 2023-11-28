using Data.DBContext;

namespace Data.Model;

public class MaintenanceData : IMaintenanceData
{
    private IsaDBContext _isaDb;

    public MaintenanceData(IsaDBContext isaDb)
    {
        _isaDb = isaDb;
    }

    public bool create(MaintenanceActivity activity)
    {
        try
        {
            _isaDb.MaintenanceActivities.Add(activity);
            _isaDb.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IsaDBContext GetDbContext()
    {
        return _isaDb;
    }
    
    public Product getBySerialNumber(string serialnumber)
    {
        return _isaDb.Products.Where(t => t.serialNumber == serialnumber).FirstOrDefault();
    }
}