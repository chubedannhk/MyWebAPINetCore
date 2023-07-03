using DemoSession2WebAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace DemoSession2WebAPI.Service;

public class CategoryServiceImpl : CategoryService
{

    private DatabaseContext db;

    public CategoryServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public dynamic findAll()
    {
      return db.Categories.Select(c => new {
         Id = c.Id,
          Name = c.Name }).ToList();
    }

    public dynamic findById(int id)
    {
        return db.Categories.Where(p => p.Id == id).Select(p => new
        {
            Id = p.Id,
            Name = p.Name
        }).FirstOrDefault();
    }
}
