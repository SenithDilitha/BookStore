﻿using BookDetailsService.Domain.Entities;

namespace BookListService.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishedDate { get; set; }

    public virtual BookDetails BookDetails { get; set; }
}