using Microsoft.EntityFrameworkCore;

namespace MyLearnAPI.Data;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) 
    {
    }

    // tao moi quan he
    #region DbSet
    public DbSet<Book> Books { get; set; }
    #endregion
}
