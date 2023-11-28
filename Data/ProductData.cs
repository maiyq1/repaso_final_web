using Data.DBContext;
using Data.Interfaces;
using Data.Model;

namespace Data;

public class ProductData : IProductData
{
    private IsaDBContext _IsaDbContext;

    public ProductData(IsaDBContext isaDbContext)
    {
        _IsaDbContext = isaDbContext;
    }
    
    public bool create(Product product)
    {
        try
        {
            _IsaDbContext.Products.Add(product);
            _IsaDbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product getById(int id)
    {
        return _IsaDbContext.Products.Where(p => p.id == id && p.isActive).FirstOrDefault();
    }
}