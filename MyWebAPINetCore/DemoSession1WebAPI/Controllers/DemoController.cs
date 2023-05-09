using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace DemoSession1WebAPI.Controllers;
[Route("api/demo")]
public class DemoController : Controller
{
    // produces dung de xac dinh kieu du lieu dang cung cap la json
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpGet("demo1")]
    public IActionResult Demo1()
    {
        try
        {
            // ma 200
            return Ok(new
            {
                Msg = "Hello master nguyenhoangkhai"
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

    // produces dung de xac dinh kieu du lieu dang cung cap la json
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpGet("demo2/{id}")]
    public IActionResult Demo2(int id)
    {
        try
        {
            Debug.WriteLine("Id: "+ id);
            // ma 200
            return Ok();
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }

   
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpGet("demo3")]
    public IActionResult Demo3(int id)
    {
        try
        {
            Debug.WriteLine("Id: " + id);
            // ma 200
            return Ok();
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpGet("demo4/{startDate}/{endDate}")]
    public IActionResult Demo4(string startDate, string endDate)
    {
        try
        {
            var start = DateTime.ParseExact(startDate, "dd-MM-yyyy", 
                CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(endDate, "dd-MM-yyyy",
                CultureInfo.InvariantCulture);
            Debug.WriteLine("Start: " + start.ToString("yyyy-MM-dd"));
            Debug.WriteLine("End: " + end.ToString("yyyy-MM-dd"));
            return Ok();
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}
