using System.Linq.Expressions;
using BookListService.Domain.Entities;
using BookListService.Domain.Interfaces;

namespace BookListService.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task<IEnumerable<Book>> GetBooksAsync(string genre, string author, int page, int pageSize)
    {
        Expression<Func<Book, bool>> filter = b => b.Genre == genre && b.Author == author;

        return _bookRepository.GetBooksAsync(filter, page, pageSize);
    }
}