
using DemoSession2WebAPI.Helpers;
using DemoSession2WebAPI.Models;
using DemoSession2WebAPI.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace DemoSession2WebAPI.Controllers;
[Route("api/product")]

public class ProductController : ControllerBase
{
    // inject len 
    private ProductSerivice productserivice;
    private IWebHostEnvironment webHostEnvironment;
    public ProductController(ProductSerivice _productserivice, IWebHostEnvironment _webHostEnvironment)
    {
        productserivice = _productserivice;
        webHostEnvironment = _webHostEnvironment;
    }
    
    [Produces("application/json")]
    [HttpGet("findall")]
    public IActionResult FindAll()
    {
        try
        {
           var fillAll = productserivice.findAll();
            return Ok(fillAll);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    [HttpGet("findall2")]
    public IActionResult FindAll2()
    {
        try
        {
            var fillAll = productserivice.findAll2();
            return Ok(fillAll);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    // lay 1 san pham
    [Produces("application/json")]
    [HttpGet("findbyid/{id}")]
    public IActionResult FindById(int id)
    {
        try
        {
            var filfById = productserivice.findById(id);
            return Ok(filfById);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    [HttpGet("search/{keyword}")]
    public IActionResult searchBykeyword(string keyword)
    {
        try
        {
            var searchByKerword = productserivice.searchBykeyword(keyword);
            return Ok(searchByKerword);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    [Produces("application/json")]
    [HttpGet("searchbycategoryId/{categoryId}")]
    public IActionResult SearchByCategoryId(int categoryId)
    {
        try
        {
            if(categoryId == -1)
            {
                var fillAll = productserivice.findAll2();
                return Ok(fillAll);
            }
            else
            {
                var seachbycategoryid = productserivice.searchbyCategoryId(categoryId);
                return Ok(seachbycategoryid);
            }
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    //nhan du lieu la consumes
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("created")]
    public IActionResult Created([FromBody] Product product)
    {
        try
        {
            return Ok(new
            {
                status = productserivice.Created(product)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

   
 
    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(new
            {
                Result = productserivice.Delete(id)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    //nhan du lieu la consumes
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("update")]
    public IActionResult Update([FromBody] Product product)
    {
        try
        {
            return Ok(new
            {
                Result = productserivice.Update(product)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }


    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    [HttpPost("created2")]
    // cung luc nhan hinh anh va chuoi json
    public IActionResult Created2(IFormFile photo, string strproduct)
    {
        try
        {
            var fileName = FileHelper.generateFileName(photo.FileName);
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(fileStream);
                
            }
            var product = JsonConvert.DeserializeObject<Product>(strproduct, new IsoDateTimeConverter
            {
                DateTimeFormat = "dd/MM/yyyy"
            });
            product.Photo = fileName;
            bool result = productserivice.Created(product);
            return Ok(new
            {
                Result = result
            });
            //Debug.WriteLine("Name: " + product.Name);
            //Debug.WriteLine("Name: " + product.Price);
            //Debug.WriteLine("File Info");
            //Debug.WriteLine("Name: " + photo.FileName);
            //Debug.WriteLine("Type: " + photo.ContentType);
            //Debug.WriteLine("Size: " + photo.Length);
            //Debug.WriteLine(product);
   
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }


    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    [HttpPost("update2")]
    public IActionResult Update2(IFormFile photo, string strproduct)
    {
        try
        {
            var product = JsonConvert.DeserializeObject<Product>(strproduct, new IsoDateTimeConverter
            {
                DateTimeFormat = "dd/MM/yyyy"
            });
            // neu co anh thi thi moi thuc hien update
            if (photo != null)
            {
                var fileName = FileHelper.generateFileName(photo.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);

                }
                // loai lai ten file moi
                product.Photo = fileName;
            }
            else
            {
                product.Photo = productserivice.findbyId(product.Id).Photo;
            }
          
            bool result = productserivice.Update(product);
            return Ok(new
            {
                Result = result
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

}

