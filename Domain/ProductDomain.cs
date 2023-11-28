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
        //RECUERDA CAMBIAR ESTOS VALORES NUMERICOS POR CONSTANTES, NALDO CTMRE >:V
        //const int OperationalProduct = 1 
        //const int UnoperationalProduct = 2 
        if (_ProductData.GetDbContext().Products.Any(item => item.serialNumber == product.serialNumber))
        {
            return false;
        }

        if (product.statusDescription != "OPERATIONAL" && product.statusDescription != "UNOPERATIONAL")
        {
            return false;
            
        }
        else
        {
            if (product.statusDescription == "OPERATIONAL")
            {
                product.status = 1;
            }
            else
            {
                product.status = 2;
            }
            return _ProductData.create(product);
        }
    }

    public Product getById(int id)
    {
        throw new NotImplementedException();
    }

}