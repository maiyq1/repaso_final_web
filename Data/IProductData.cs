using Data.Model;

namespace Data;

public interface IProductData
{
    public bool create(Product product);

    public Product getById(int id);
}