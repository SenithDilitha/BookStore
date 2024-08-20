using System.Linq.Expressions;
using BookListService.Domain.Entities;

namespace BookListService.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync(Expression<Func<Book, bool>> filter, int page = 1, int pageSize = 10);
}