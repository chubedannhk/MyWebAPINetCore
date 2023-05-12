using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Repositories;

namespace MyWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService accountService;

    public AccountController(AccountService _accountService)
    {
        accountService = _accountService;
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpModel signupmodel)
    {
        var result = await accountService.SignUpAsync(signupmodel);
        if (result.Succeeded)
        {
            return Ok(result.Succeeded);
        }
        return BadRequest();
    }
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SignInModel signinmodel)
    {
        var result = await accountService.SignInAsync(signinmodel);
        if (string.IsNullOrEmpty(result))
        {
            return BadRequest();
        }
        return Ok(result);
    }
}
