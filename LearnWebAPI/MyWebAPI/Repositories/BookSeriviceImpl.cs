using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Repositories;

public class BookSeriviceImpl : BookService
{
    private readonly BookStoreContext db;
    private readonly IMapper mapper;

    public BookSeriviceImpl(BookStoreContext _context, IMapper _mapper)
    {
        db = _context;
        mapper = _mapper;

    }
    public async Task<int> AddBookAsync(BookModel model)
    {
        var newBook = mapper.Map<Book>(model);
        db.Books!.Add(newBook);
        await db.SaveChangesAsync();
        return newBook.Id;
    }

    public async Task DeleteBookAsync(int id)
    {
       var deleteBook = db.Books!.SingleOrDefault(p => p.Id == id);
        if(deleteBook != null)
        {
            db.Books!.Remove(deleteBook);
            await db.SaveChangesAsync();
        }
    }

    // lay danh sach nhung quyen sach
    public async Task<List<BookModel>> getAllBookAsync()
    {
        var books = await db.Books.ToListAsync();
        return mapper.Map<List<BookModel>>(books);
    }

    // lay mot quyen sach
    public async Task<BookModel> getBookAsync(int id)
    {
        var books = await db.Books!.FindAsync(id);
        return mapper.Map<BookModel>(books);
    }

    public async Task UpdateBookAsync(int id, BookModel model)
    {
       if(id == model.Id)
        {
            var updateBook = mapper.Map<Book>(model);
            db.Books!.Update(updateBook);
            await db.SaveChangesAsync();
           
        }
    }
}