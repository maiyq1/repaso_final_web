using Data.Model;

namespace Domain;

public interface IProductDomain
{
    public bool create(Product product);

    public Product getById(int id);
}