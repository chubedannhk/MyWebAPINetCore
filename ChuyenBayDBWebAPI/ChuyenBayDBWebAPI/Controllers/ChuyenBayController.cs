using ChuyenBayDBWebAPI.Helpers;
using ChuyenBayDBWebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using ChuyenBayDBWebAPI.Models;

namespace ChuyenBayDBWebAPI.Controllers;
[Route("api/chuyenbay")]
public class ChuyenBayController : Controller
{
    private ChuyenBayService chuyenbayService;
    private IWebHostEnvironment webHostEnvironment;
    public ChuyenBayController(ChuyenBayService _chuyenbayService, IWebHostEnvironment _webHostEnvironment)
    {
        chuyenbayService = _chuyenbayService;
        webHostEnvironment = _webHostEnvironment;
    }
    [Produces("application/json")]
    [HttpGet("findall")]
    public IActionResult FindAll()
    {
        try
        {
            var fillAll = chuyenbayService.findAll();
            return Ok(fillAll);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    // methods created chuyen bay
    //[Produces("application/json")]
    //[HttpPost("created")]

    //public IActionResult Created(string strchuyenbay)
    //{
    //    try
    //    {

    //        var chuyenbay = JsonConvert.DeserializeObject<ChuyenBay>(strchuyenbay, new IsoDateTimeConverter
    //        {
    //            DateTimeFormat = "dd/MM/yyyy"
    //        });
    //        bool result = chuyenbayService.Created(chuyenbay);
    //        return Ok(new
    //        {
    //            Result = result
    //        });

    //    }
    //    catch (Exception ex)
    //    {
    //        // ma 400: la co loi roi
    //        return BadRequest(ex);
    //    }
    //}
    [Produces("application/json")]
    [HttpPost("created")]
    // cùng lúc nhận hình ảnh và chuỗi JSON
    public IActionResult Created([FromBody] ChuyenBay chuyenbay)
    {
        try
        {
            bool result = chuyenbayService.Created(chuyenbay);
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
    [HttpPost("update")]
    public IActionResult Update([FromBody] ChuyenBay chuyenbay)
    {
        try
        {
            bool result = chuyenbayService.Update(chuyenbay);
            return Ok(new
            {
                Result = result
            });
        }
        catch (Exception ex)
        {
            // Mã 400: Có lỗi xảy ra
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    [HttpGet("findbymacb/{macb}")]
    public IActionResult FindById(int macb)
    {
        try
        {
            var findbymacb = chuyenbayService.findbyMacb( macb );
            return Ok(findbymacb);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    [Produces("application/json")]
    [HttpGet("findprice/{macb}/{a}")]
    public IActionResult FindPrice(int macb, int a)
    {
        try
        {
            var findbymacb = chuyenbayService.findPrice(macb,a);
            return Ok(findbymacb);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    [Produces("application/json")]
    [HttpGet("findprice2/{macb}/{b}")]
    public IActionResult FindPrice2(int macb, int b)
    {
        try
        {
            var findbymacb = chuyenbayService.findPrice2(macb, b);
            return Ok(findbymacb);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

  
}
