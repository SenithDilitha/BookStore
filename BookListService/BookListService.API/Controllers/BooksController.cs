using BookListService.Domain.Entities;
using BookListService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookListService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> Books([FromQuery] string genre, [FromQuery] string author,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var books = await _bookService.GetBooksAsync(genre, author, page, pageSize);
        return Ok(books);
    }
}