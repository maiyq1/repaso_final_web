using Data.Model;

namespace Data.Interfaces;

public interface IProductData
{
    public bool create(Product product);
    public Product getById(int id);
}