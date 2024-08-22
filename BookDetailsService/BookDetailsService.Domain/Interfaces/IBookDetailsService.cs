using BookDetailsService.Domain.Entities;

namespace BookDetailsService.Domain.Interfaces;

public interface IBookDetailsService
{
    Task<BookDetails> GetBookDetailsAsync(int bookId);
    Task AddBookDetailsAsync(BookDetails bookDetails);
    Task UpdateBookDetailsAsync(BookDetails bookDetails);
    Task DeleteBookDetailsAsync(int bookId);
}