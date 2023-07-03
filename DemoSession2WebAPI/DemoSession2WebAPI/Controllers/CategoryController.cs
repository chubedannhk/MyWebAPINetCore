using DemoSession2WebAPI.Models;
using DemoSession2WebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoSession2WebAPI.Controllers;
[Route("api/category")]

public class CategoryController : Controller
{ // inject len 
    private CategoryService categoryservice;
    public CategoryController(CategoryService _categoryservice)
    {
        categoryservice = _categoryservice;
    }


    [Produces("application/json")]
    [HttpGet("findall")]

    public IActionResult FindAll()
    {
        try
        {
            var findall = categoryservice.findAll();
            return Ok(findall);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    [Produces("application/json")]
    [HttpGet("findbyid/{id}")]

    public IActionResult FindById(int id)
    {
        try
        {
            var findbyid = categoryservice.findById(id);
            return Ok(findbyid);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

}
