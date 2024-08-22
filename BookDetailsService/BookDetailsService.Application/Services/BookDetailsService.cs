using BookDetailsService.Domain.Entities;
using BookDetailsService.Domain.Interfaces;

namespace BookDetailsService.Application.Services;

public class BookDetailsService : IBookDetailsService
{
    private readonly IBookDetailsRepository _bookDetailsRepository;

    public BookDetailsService(IBookDetailsRepository bookDetailsRepository)
    {
        _bookDetailsRepository = bookDetailsRepository;
    }

    public async Task<BookDetails> GetBookDetailsAsync(int bookId)
    {
        return await _bookDetailsRepository.GetBookDetailsAsync(bookId);
    }

    public async Task AddBookDetailsAsync(BookDetails bookDetails)
    {
        await _bookDetailsRepository.AddBookDetailsAsync(bookDetails);
    }

    public async Task UpdateBookDetailsAsync(BookDetails bookDetails)
    {
        await _bookDetailsRepository.UpdateBookDetailsAsync(bookDetails);
    }

    public async Task DeleteBookDetailsAsync(int bookId)
    {
        await _bookDetailsRepository.DeleteBookDetailsAsync(bookId);
    }
}