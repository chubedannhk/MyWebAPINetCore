using DemoSession2WebAPI.Models;

namespace DemoSession2WebAPI.Service;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    public AccountServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    // 2. login vao 
    public Account Authenticate(string username, string password)
    {

        var account = db.Accounts.SingleOrDefault(a => a.Username == username);

        if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.Password))
        {
            return null;
        }

        return account;

    }

    //1. tạo tài khoản mới
    public bool CreateAccount(Account account)
    {
        try
        {
            // Kiểm tra xem username đã tồn tại chưa
            if (db.Accounts.Any(a => a.Username == account.Username))
            {
                return false;
            }

            // Mã hóa password bằng bcrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(account.Password);

            // Tạo mới tài khoản
            var newAccount = new Account
            {
                Username = account.Username,
                Password = hashedPassword,
                FullName = account.FullName,
                Email = account.Email
            };
            db.Accounts.Add(newAccount);

            // Lưu thay đổi vào database
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Login(string username, string password)
    {
        return db.Accounts.Count(a => a.Username == username && a.Password == password) >0;  
    }
}
