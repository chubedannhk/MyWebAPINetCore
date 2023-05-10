using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Repositories;

public interface BookService
{
    // lay tat ca phan tu trong book
    public Task<List<BookModel>> getAllBookAsync();
    // lay mot quyen sach
    public Task<BookModel> getBookAsync(int id);
    // them sach
    public Task<int> AddBookAsync(BookModel model);
    // update
    public Task UpdateBookAsync(int id, BookModel model);
    // xoa
    public Task DeleteBookAsync(int id);


}
