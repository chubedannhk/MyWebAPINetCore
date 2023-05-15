using Information_Flight.Service;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Information_Flight.Controllers;
[Route("api/chuyenbay")]
public class ChuyenbayController : Controller
{
    private ChuyenBayService chuyenBayService;
    public ChuyenbayController(ChuyenBayService _chuyenBayService)
    {
        chuyenBayService = _chuyenBayService;
    }

    [Produces("application/json")]
    [HttpGet("findall/{ngaydi}")]
    public IActionResult FindAll(DateTime ngaydi)
    {
        try
        {
            var fillAll = chuyenBayService.findAllChuyenBay(ngaydi);
            return Ok(fillAll);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}
