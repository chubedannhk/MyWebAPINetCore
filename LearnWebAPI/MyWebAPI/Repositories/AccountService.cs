using Microsoft.AspNetCore.Identity;
using MyWebAPI.Models;

namespace MyWebAPI.Repositories;

public interface AccountService
{
    public Task<IdentityResult> SignUpAsync(SignUpModel model);
    public Task<string> SignInAsync(SignInModel model);
}
