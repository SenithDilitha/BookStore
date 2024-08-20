using System.Linq.Expressions;
using System.Text.Json;
using BookListService.Domain.Entities;
using BookListService.Domain.Interfaces;

namespace BookListService.Infrastructure.Data;

public class BookRepository : IBookRepository
{
    private readonly string _filePath =
        "D:\\Interviews\\Assignments\\BookStoreBackEnd\\BookListService\\BookListService.Infrastructure\\Data\\BookStore.json";

    public async Task<IEnumerable<Book>> GetBooksAsync(Expression<Func<Book, bool>> filter, int page = 1,
        int pageSize = 10)
    {
        var books = await ReadBooksFromFileAsync();

        if (filter != null) books = books.AsQueryable().Where(filter.Compile());

        return books.Skip((page - 1) * pageSize).Take(pageSize);
    }

    private async Task<IEnumerable<Book>> ReadBooksFromFileAsync()
    {
        if (!File.Exists(_filePath)) return Enumerable.Empty<Book>();

        var json = await File.ReadAllBytesAsync(_filePath);
        return JsonSerializer.Deserialize<IEnumerable<Book>>(json) ?? Enumerable.Empty<Book>();
    }
}