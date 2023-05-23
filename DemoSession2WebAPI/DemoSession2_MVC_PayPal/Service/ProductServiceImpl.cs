using DemoSession2_MVC_PayPal.Models;

namespace DemoSession2_MVC_PayPal.Service;

public class ProductServiceImpl : ProductService
{
    private DatabaseContext db;
    public ProductServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public List<Product> GetListProduct()
    {
        return db.Products.ToList();
    }
}
