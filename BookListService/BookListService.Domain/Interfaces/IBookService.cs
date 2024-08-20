using BookListService.Domain.Entities;

namespace BookListService.Domain.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync(string genre, string author, int page, int pageSize);
}