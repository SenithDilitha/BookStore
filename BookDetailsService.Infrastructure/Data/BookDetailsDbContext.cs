using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDetailsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookDetailsService.Infrastructure.Data
{
    public class BookDetailsDbContext : DbContext
    {
        public BookDetailsDbContext(DbContextOptions<BookDetailsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetails>()
                .HasOne(d => d.Book);
        }
    }
}
