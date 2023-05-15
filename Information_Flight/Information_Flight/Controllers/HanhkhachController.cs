using Information_Flight.Service;
using Microsoft.AspNetCore.Mvc;

namespace Information_Flight.Controllers;
[Route("api/hanhkhach")]
public class HanhkhachController : Controller
{
    private HanhKhachService hanhKhachService;
    public HanhkhachController(HanhKhachService _hanhKhachService)
    {
        hanhKhachService = _hanhKhachService;
    }
    [Produces("application/json")]
    [HttpGet("findbyhoten/{hoten}")]
    public IActionResult FindById(string hoten)
    {
        try
        {
            var findbyhoten = hanhKhachService.findByHoTen(hoten);
            return Ok(findbyhoten);
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}
