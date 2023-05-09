using DemoSession1WebAPI.Models;
using DemoSession1WebAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession1WebAPI.Controllers;
[Route("api/account")]
public class AccountController : Controller
{
    // inject len 
    private AccountService accountService;
    public AccountController(AccountService _accountService)
    {
        accountService = _accountService;
    }
    // produces dung de xac dinh kieu du lieu dang cung cap la json
    [Produces("application/json")]
    // httpget dung de do du lieu ra
    [HttpPost("login")]
    public IActionResult Login([FromBody] Account account)
    {
        try
        {

            return Ok(new
            {
                status = accountService.Login(account.Username, account.Password)
            });
        }
        catch (Exception ex)
        {
            // ma 400: la co loi roi
            return BadRequest(ex);
        }
    }
}

