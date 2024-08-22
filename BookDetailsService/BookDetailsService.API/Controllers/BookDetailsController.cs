using BookDetailsService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDetailsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {

        private readonly IBookDetailsService _bookDetailsService;

        public BookDetailsController(IBookDetailsService bookDetailsService)
        {
            _bookDetailsService = bookDetailsService;
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<BookDetails>> GetBookDetails(int bookId)
        {
            var bookDetails = await _bookDetailsService.GetBookDetailsAsync(bookId);
            if (bookDetails == null)
            {
                return NotFound();
            }
            return Ok(bookDetails);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBookDetails(BookDetails bookDetails)
        {
            await _bookDetailsService.AddBookDetailsAsync(bookDetails);
            return CreatedAtAction(nameof(GetBookDetails), new { bookId = bookDetails.BookId }, bookDetails);
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult> UpdateBookDetails(int bookId, BookDetails bookDetails)
        {
            if (bookId != bookDetails.BookId)
            {
                return BadRequest();
            }

            await _bookDetailsService.UpdateBookDetailsAsync(bookDetails);
            return NoContent();
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBookDetails(int bookId)
        {
            await _bookDetailsService.DeleteBookDetailsAsync(bookId);
            return NoContent();
        }
    }
}
