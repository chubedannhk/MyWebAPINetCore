using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Repositories;

namespace MyWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly BookService bookService;

    public ProductController(BookService _bookService)
    {
        bookService = _bookService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        try
        {
            return Ok(await bookService.getAllBookAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        try
        {
            return Ok(await bookService.getBookAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // them sach
    [HttpPost]
    public async Task<IActionResult> AddNewBook(BookModel modle)
    {
        try
        {
            var newBookId = await bookService.AddBookAsync(modle);
            var book = await bookService.getBookAsync(newBookId);
            return book == null ? NotFound() : Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // update sach
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, BookModel model)
    {

        if (id != model.Id)
        {
            return NotFound();
        }
        await bookService.UpdateBookAsync(id, model);
        return Ok();

    }

    // 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            await bookService.DeleteBookAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
