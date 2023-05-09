using DemoSession1WebAPI.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace DemoSession1WebAPI.Service;

public class ProductServiceImpl : ProductService
{
    // buoi 2
    // tao
    public bool Create(Product product)
    {
        Debug.WriteLine("Create Product");
        Debug.WriteLine("Id: "+product.Id);
        Debug.WriteLine("Name: "+product.Name);
        Debug.WriteLine("Price: " +product.Price);
        Debug.WriteLine("Status: " + product.Status);
        Debug.WriteLine("Created: " + product.Created.ToString("dd/MM/yyyy"));
        return true;
    }
    //update
    public bool Update(Product product)
    {
        Debug.WriteLine("Create Product");
        Debug.WriteLine("Id: " + product.Id);
        Debug.WriteLine("Name: " + product.Name);
        Debug.WriteLine("Price: " + product.Price);
        return true;
    }
    // xoa 
    public bool Delete(int id)
    {
        Debug.WriteLine("Deleted Id: " + id);
        return true;
    }
    // buoi 1
    public Product find()
    {
        return new Product
        {
            Id = 123,
            Name = "Test",
            Created = DateTime.Now,
            Price = 4.5,
            Quantity = 100,
            Status = true
        };
    }

    public List<Product> findAll()
    {
        return new List<Product>
      {
          new Product
          {
            Id = 1,
            Name = "Test",
            Created = DateTime.ParseExact("20/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 4.5,
            Quantity = 100,
            Status = true
          },
          new Product
          {
            Id = 2,
            Name = "Tester",
            Created = DateTime.ParseExact("20/11/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 5.5,
            Quantity = 130,
            Status = false
          },
          new Product
          {
            Id = 3,
            Name = "Test Game",
            Created = DateTime.ParseExact("20/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 6.5,
            Quantity = 200,
            Status = true
          },
          new Product
          {
            Id = 4,
            Name = "HoangKhai",
            Created = DateTime.ParseExact("11/01/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 7.5,
            Quantity = 1000,
            Status = true
          },
      };
    }

 

    public List<Product> FindProductByName(string name)
    {
        var allProducts = new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Test",
            Created = DateTime.ParseExact("20/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 4.5,
            Quantity = 100,
            Status = true
        },
        new Product
        {
            Id = 2,
            Name = "Tester",
            Created = DateTime.ParseExact("20/11/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 5.5,
            Quantity = 130,
            Status = false
        },
        new Product
        {
            Id = 3,
            Name = "Test Game",
            Created = DateTime.ParseExact("20/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 6.5,
            Quantity = 200,
            Status = true
        },
        new Product
        {
            Id = 4,
            Name = "HoangKhai",
            Created = DateTime.ParseExact("11/01/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 7.5,
            Quantity = 1000,
            Status = true
        }
    };

        var matchedProducts = allProducts.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
        return matchedProducts;
    }

    public List<Product> FindProductByPriceRange(double minPrice, double maxPrice)
    {
        var allProducts = new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Test",
            Created = DateTime.ParseExact("20/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 4.5,
            Quantity = 100,
            Status = true
        },
        new Product
        {
            Id = 2,
            Name = "Tester",
            Created = DateTime.ParseExact("20/11/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 5.5,
            Quantity = 130,
            Status = false
        },
        new Product
        {
            Id = 3,
            Name = "Test Game",
            Created = DateTime.ParseExact("20/12/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 6.5,
            Quantity = 200,
            Status = true
        },
        new Product
        {
            Id = 4,
            Name = "HoangKhai",
            Created = DateTime.ParseExact("11/01/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            Price = 7.5,
            Quantity = 1000,
            Status = true
        }
    };
        var priceProduct = allProducts.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        return priceProduct;
    }

   
}

