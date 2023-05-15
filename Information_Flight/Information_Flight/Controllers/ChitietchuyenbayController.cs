using Information_Flight.Service;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Information_Flight.Controllers;
[Route("api/chitiet")]
public class ChitietchuyenbayController : Controller
{
    private ChiTietService chitietService;
    public ChitietchuyenbayController(ChiTietService _chitietService)
    {
        chitietService = _chitietService;
    }

    [Produces("application/json")]
    [HttpGet("findbyid/{mact}")]
    public IActionResult FindById(int mact)
    {
        try
        {
            var findbyid = chitietService.findIdChiTietChuyenBay(mact);
            return Ok(findbyid);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}
