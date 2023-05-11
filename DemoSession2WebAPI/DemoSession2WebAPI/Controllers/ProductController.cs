using DemoSession2WebAPI.Models;
using DemoSession2WebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession2WebAPI.Controllers;
[Route("api/product")]

public class ProductController : ControllerBase
{
    // inject len 
    private ProductSerivice productserivice;
    public ProductController(ProductSerivice _productserivice)
    {
        productserivice = _productserivice;
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
                status = productserivice.Delete(id)
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
                status = productserivice.Update(product)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}

