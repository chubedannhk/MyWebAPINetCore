using DemoSession2WebAPI.Models;
using DemoSession2WebAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoSession2WebAPI.Controllers;
[Route("api/account")]
/*
 * tao tai khoan moi voi password ma hoa bycrypt
 * login tai khoan
 * cap nhat tai khoan
 * liet ke ca hoa don dc lap cho 1 khach hang
 * tinh tong tien va dem co bao nhieu san pham trong 1 hoa don 
 * liet ke cac hoa don duoc lap trong 1 khoang thoi gian
 * liet ke n hoa don moi nhat
 * liet ke cac san pham trong 1 hoa don
 */
public class AccountController : Controller
{ // inject len 
    private AccountService accountService;
    public AccountController(AccountService _accountService)
    {
        accountService = _accountService;
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult CreateAccount([FromBody] Account account)
    {
        try
        {
          
            bool created = accountService.CreateAccount(account);
            if (created)
            {
                return Ok("Account created successfully");
            }
            else
            {
                return BadRequest("Username already exists");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // login
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("login")]
    public IActionResult Login([FromBody] Account account)
    {
        var accounts = accountService.Authenticate(account.Username, account.Password);

        if (accounts == null)
        {
            return Unauthorized();
        }

        return Ok("login success");
    }

}
