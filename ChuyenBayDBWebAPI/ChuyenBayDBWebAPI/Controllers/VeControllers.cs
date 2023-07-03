using ChuyenBayDBWebAPI.Helpers;
using ChuyenBayDBWebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using ChuyenBayDBWebAPI.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ChuyenBayDBWebAPI.Controllers;
[Route("api/ve")]
public class VeController : Controller
{
    private VeService veSerivce;
    private IWebHostEnvironment webHostEnvironment;
    public VeController(VeService _veSerivce, IWebHostEnvironment _webHostEnvironment)
    {
        veSerivce = _veSerivce;
        webHostEnvironment = _webHostEnvironment;
    }
    [Produces("application/json")]
    [HttpGet("findall")]
    public IActionResult FindAll()
    {
        try
        {
            var fillAll = veSerivce.findAll();
            return Ok(fillAll);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    
    [Produces("application/json")]
    [HttpPost("created")]
    // cùng lúc nhận hình ảnh và chuỗi JSON
    public IActionResult Created([FromBody] Ve ve)
    {
        try
        {
            bool result = veSerivce.Created(ve);
            return Ok(new
            {
                Result = result
            });
        }
        catch (Exception ex)
        {
            // mã 400: có lỗi xảy ra
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    [HttpGet("findbymacb/{macb}")]
    public IActionResult FindById(int macb)
    {
        try
        {
            var findbymacb = veSerivce.findbyMacb(macb);
            return Ok(findbymacb);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }


    [Produces("application/json")]
    [HttpDelete("delete/{mave}")]
    public IActionResult Delete(int mave)
    {
        try
        {
            return Ok(new
            {
                Result = veSerivce.Delete(mave)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

 
    // search
    [Produces("application/json")]
    [HttpGet("searchbyloaighe/{macb}/{loaighe}")]
    public IActionResult searchByLoaighe(int macb, int loaighe)
    {
        try
        {
            if(loaighe == -1)
            {
                var findbymacb = veSerivce.findbyMacb(macb);
                return Ok(findbymacb);
            }
            else
            {
                var searchbyloaighe = veSerivce.searchByLoaighe(macb, loaighe);
                return Ok(searchbyloaighe);
            }
          
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    [HttpGet("searchbygiaghe/{macb}/{giaghe}")]
    public IActionResult searchByGiaghe(int macb, int giaghe)
    {
        try
        {
            if (giaghe == -1)
            {
                var findbymacb = veSerivce.findbyMacb(macb);
                return Ok(findbymacb);
            }
            else
            {
                var searchbygiaghe = veSerivce.searchByGiaghe(macb, giaghe);
                return Ok(searchbygiaghe);
            }
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}
