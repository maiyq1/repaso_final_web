using Data.DBContext;

namespace Data.Model;

public class ProductData : IProductData
{
    private IsaDBContext _isaDb;

    public ProductData(IsaDBContext isaDb)
    {
        _isaDb = isaDb;
    }
    
    public bool create(Product product)
    {
        try
        {
            _isaDb.Products.Add(product);
            _isaDb.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public Product getById(int id)
    { 
        return _isaDb.Products.Where(t => t.id == id).FirstOrDefault();
    }

    public IsaDBContext GetDbContext()
    {
        return _isaDb;
    }

   
}