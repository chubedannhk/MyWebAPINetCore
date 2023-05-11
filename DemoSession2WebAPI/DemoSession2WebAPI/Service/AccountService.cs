using DemoSession2WebAPI.Models;

namespace DemoSession2WebAPI.Service;

public interface AccountService
{
    public bool CreateAccount(Account account);

    public Account Authenticate(string username, string password);
}
