using DemoSession1WebAPI.Models;

namespace DemoSession1WebAPI.Service;

public class AccountServiceImpl : AccountService
{
    private List<Account> accounts;
    public AccountServiceImpl()
    {
        accounts = new List<Account>
        {
            new Account{
                Username = "acc1",
                Password = "123",
                Fullname = "Name 1"
            },
             new Account{
                Username = "acc2",
                Password = "123",
                Fullname = "Name 2"
            },
              new Account{
                Username = "acc3",
                Password = "123",
                Fullname = "Name 3"
            }
        };
    }
    public bool Login(string username, string password)
    {
       return accounts.Count(a => a.Username == username && a.Password == password) > 0;
    }
}
