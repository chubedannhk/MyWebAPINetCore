using DemoSession1WebAPI.Helpers;
using DemoSession1WebAPI.Models;
using DemoSession1WebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace DemoSession1WebAPI.Controllers;
[Route("api/product")]
public class ProductController : Controller
{
    // inject len 
    private IWebHostEnvironment webHostEnvironment;
    private ProductService productService;
    private IConfiguration configuration;
    public ProductController(ProductService _productService, IWebHostEnvironment _webHostEnvironment, IConfiguration _configuration)
    {
        productService = _productService;
        webHostEnvironment = _webHostEnvironment;
        configuration = _configuration;
    }
    // produces dung de xac dinh kieu du lieu dang cung cap la json
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpGet("find")]
    public IActionResult Find()
    {
        try
        {

            //return Ok(productService.find());
            return Ok(productService.find());
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpGet("findAll")]
    public IActionResult FindAll()
    {
        try
        {

            //return Ok(productService.find());
            return Ok(productService.findAll());
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    /* xay dung web api thuc hien cac yeu cau sau: 
    1. Liet ke cac san pham co ten chua tu khoa
    2. Liet ke cac san pham co gia nam trong 1 khoang
    3. Liet ke cac san pham duoc san xuat trong 1 thang cua nam
    4. Liet ke cac san pham duoc san xuat trong 1 khoang thoi gian 
    5. Kiem tra 1 ten san pham co ton tai hay khong
    6. Dem va tinh tongtien cac san pham thoe 1 status
    */

    //1 Liet ke cac san pham co ten chua tu khoa
    [Produces("application/json")]
    [HttpGet("search/{name}")]
    public IActionResult FindProductByKeyword(string name)
    {
        try
        {
            //var products = productService.FindProductByName(name);

            var products = productService.findAll().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    // 2. Liet ke cac san pham co gia nam trong 1 khoang
    [Produces("application/json")]
    [HttpGet("search/{minPrice}/{maxPrice}")]
    public IActionResult FindProductByPriceRange(double minPrice, double maxPrice)
    {
        try
        {
            var products = productService.FindProductByPriceRange(minPrice, maxPrice);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    // Demo buoi 2
    // comsumes dung de nhan du lieu tu phia client
    [Consumes("application/json")]
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpPost("created")]
    public IActionResult Created([FromBody] Product product)
    {
        try
        {


            return Ok(new
            {
                status = productService.Create(product)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    // update 
    [Consumes("application/json")]
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpPut("update")]
    public IActionResult Update([FromBody] Product product)
    {
        try
        {


            return Ok(new
            {
                status = productService.Update(product)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    // deleted 

    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {


            return Ok(new
            {
                status = productService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    //upload file
    [Produces("application/json")]
    [HttpPost("upload")]
    public IActionResult Upload(IFormFile file)
    {
        try
        {

            Debug.WriteLine("File Info");
            Debug.WriteLine("File Name: " + file.FileName);
            Debug.WriteLine("File size: " + file.Length);
            Debug.WriteLine("File type: " + file.ContentType);
            // tao ten ngau nhien
            var fileName = FileHelper.generateFileName(file.FileName);
            // xay dung duong dan
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Ok(new
            {
                // tra cho client duong dan cua cai file do
                url = configuration["BaseUrl"] + "images/" + fileName
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    //upload files
    [Produces("application/json")]
    [HttpPost("uploads")]
    public IActionResult Uploads(IFormFile[] files)
    {
        try
        {

            Debug.WriteLine("File Info");
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                Debug.WriteLine("File Name: " + file.FileName);
                Debug.WriteLine("File size: " + file.Length);
                Debug.WriteLine("File type: " + file.ContentType);
                Debug.WriteLine("------------------------------");
                // tao ten ngau nhien
                var fileName = FileHelper.generateFileName(file.FileName);
                // xay dung duong dan
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    // tra ra danh sach san pham 
                    fileNames.Add(configuration["BaseUrl"] + "images/" + fileName);
                }
            }

            return Ok(fileNames);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    // upload files co duoi .csv
    [Produces("application/json")]
    [HttpPost("uploadfile")]
    public IActionResult Uploadfile(IFormFile[] files)
    {
        try
        {
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                // Check if the uploaded file is a CSV file
                if (Path.GetExtension(file.FileName) != ".csv")
                {
                    return BadRequest("Only CSV files are allowed.");
                }

                var fileName = FileHelper.generateFileName(file.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileNames.Add(configuration["BaseUrl"] + "images/" + fileName);
                }
            }
            return Ok(fileNames);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        // neu lam giao dien thi lam form như vậy
        //< form method = "post" enctype = "multipart/form-data" action = "/api/uploads" >
        //< input type = "file" name = "files" multiple />
        //< button type = "submit" > Upload </ button >
        //</ form >
    }

}
//System.IO.File.ReadAllLine("path")