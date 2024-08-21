using System.Linq.Expressions;
using BookListService.Domain.Entities;
using BookListService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookListService.Infrastructure.Data
{
    public class BookSqlServerRepository : IBookRepository
    {
        private readonly BookListDbContext _context;

        public BookSqlServerRepository(BookListDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(Expression<Func<Book, bool>> filter, int page = 1, int pageSize = 10)
        {
            return await _context.Books
                .Where(filter)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
