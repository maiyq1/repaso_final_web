using Data;
using Data.Model;

namespace Domain;

public class ProductDomain : IProductDomain
{
    public IProductData _ProductData;

    public ProductDomain(IProductData productData)
    {
        _ProductData = productData;
    }
    
    public bool create(Product product)
    {
        if (_ProductData.GetDbContext().Products.Any(item => item.serialNumber == product.serialNumber))
        {
            return false;
        }
        else
        {
            return _ProductData.create(product);
        }
    }

    public Product getById(int id)
    {
        throw new NotImplementedException();
    }

}