using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI.Data;
using MyWebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebAPI.Repositories;

public class AccountServiceImpl : AccountService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IConfiguration configuration;

    public AccountServiceImpl(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, IConfiguration _configuration)
    {
        userManager = _userManager;
        signInManager = _signInManager;
        configuration = _configuration;
    }
    public async Task<string> SignInAsync(SignInModel model)
    {
        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        if (!result.Succeeded)
        {
            return string.Empty;
        }
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, model.Email),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var authenKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(20),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)

            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        var user = new ApplicationUser
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Email
        };
        return await userManager.CreateAsync(user, model.Password);
    }
}
