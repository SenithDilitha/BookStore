using BookListService.Domain.Entities;

namespace BookDetailsService.Domain.Entities;

public class BookDetails
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public int NumberOfPages { get; set; }
    public string Publisher { get; set; }
    public string Summary { get; set; }

    public int BookId { get; set; }
}