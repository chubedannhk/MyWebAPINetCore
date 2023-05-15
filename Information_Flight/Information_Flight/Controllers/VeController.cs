using Information_Flight.Service;
using Microsoft.AspNetCore.Mvc;

namespace Information_Flight.Controllers;
[Route("api/ve")]
public class VeController : Controller
{

    private VeService veService;
    public VeController(VeService _veService)
    {
        veService = _veService;
    }
    [Produces("application/json")]
    [HttpGet("findbyve/{mahk}")]
    public IActionResult FindByVe(int mahk)
    {
        try
        {
            var findByVe = veService.findByVe(mahk);
            return Ok(findByVe);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    [Produces("application/json")]
    [HttpGet("count/{mahk}")]
    public IActionResult Count(int mahk)
    {
        try
        {
            var countve = veService.countByVe(mahk);
            return Ok(countve);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
    [Produces("application/json")]
    [HttpGet("sum/{mahk}")]
    public IActionResult Sum(int mahk)
    {
        try
        {
            var sumVe = veService.getAverageVe(mahk);
            return Ok(sumVe);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}
