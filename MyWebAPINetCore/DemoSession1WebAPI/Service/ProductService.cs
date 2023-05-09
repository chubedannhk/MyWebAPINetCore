using DemoSession1WebAPI.Models;

namespace DemoSession1WebAPI.Service;

public interface ProductService
{

    public Product find();
    public List<Product> findAll();

    public List<Product> FindProductByName(string name);
    public List<Product> FindProductByPriceRange(double minPrice, double maxPrice);

    public bool Create(Product product);
    public bool Update(Product product);
    public bool Delete(int id);
}
