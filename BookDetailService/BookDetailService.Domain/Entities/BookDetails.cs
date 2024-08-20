namespace BookDetailService.Domain.Entities;

public class BookDetails
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int Pages { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishedDate { get; set; }
}