using DemoSession2WebAPI.Models;

namespace DemoSession2WebAPI.Service;

public class ProductServiceImpl : ProductSerivice
{

    private DatabaseContext db;
    public ProductServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
  
    public List<Product> findAll()
    {
       return db.Products.ToList();
    }

    public dynamic findAll2()
    {
        return db.Products.Select(p => new
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Quantity = p.Quantity,
            Created = p.Created,
            CategoryId = p.CategoryId,
            Description = p.Description,
            Photo = p.Photo,
            Featured = p.Featured
        }).ToList();
    }

    public dynamic findById(int id)
    {
        return db.Products.Where(p => p.Id == id).Select(p => new
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Quantity = p.Quantity,
            Created = p.Created,
            CategoryId = p.CategoryId,
            Description = p.Description,
            Photo = p.Photo,
            Featured = p.Featured

        }).FirstOrDefault();
    }
    // them san pham
    public bool Created(Product product)
    {
        try
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
    // xoa san pham
    public bool Delete(int id)
    {
        try
        {
            db.Products.Remove(db.Products.Find(id));
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
    // update
    public bool Update(Product product)
    {
        try
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

}
