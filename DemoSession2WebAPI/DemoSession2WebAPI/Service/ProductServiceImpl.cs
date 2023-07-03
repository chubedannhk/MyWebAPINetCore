using DemoSession2WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Net.Mime.MediaTypeNames;

namespace DemoSession2WebAPI.Service;

public class ProductServiceImpl : ProductSerivice
{

    private DatabaseContext db;
    private IConfiguration configuration;
    public ProductServiceImpl(DatabaseContext _db, IConfiguration _configuration)
    {
        db = _db;
        configuration = _configuration;
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
            Featured = p.Featured,
            Status = p.Status,
            Photo = configuration["BaseUrl"]+"images/"+ p.Photo,
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
            Featured = p.Featured,
            Status = p.Status,
            Photo = configuration["BaseUrl"] + "images/" + p.Photo

        }).FirstOrDefault();
    }

    public dynamic searchBykeyword(string keyword)
    {
        return db.Products.Where(p => p.Name.Contains(keyword)).Select(p => new
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Quantity = p.Quantity,
            Created = p.Created,
            CategoryId = p.CategoryId,
            Description = p.Description,
            Featured = p.Featured,
            Status = p.Status,
            Photo = configuration["BaseUrl"] + "images/" + p.Photo,
        }).ToList();
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

    public dynamic searchbyCategoryId(int catetoryId)
    {
        return db.Products.Where(p => p.CategoryId == catetoryId).Select(p => new
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Quantity = p.Quantity,
            Created = p.Created,
            CategoryId = p.CategoryId,
            Description = p.Description,
            Featured = p.Featured,
            Status = p.Status,
            Photo = configuration["BaseUrl"] + "images/" + p.Photo,
        }).ToList();
    }

    public Product findbyId(int id)
    {
        return db.Products.AsNoTracking().SingleOrDefault(p => p.Id == id);
    }
}
