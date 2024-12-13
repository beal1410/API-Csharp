using Microsoft.EntityFrameworkCore;
using API_287.Models;

namespace API_287.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; } 
        public DbSet<Author> Authors { get; set; } 
        public DbSet<Bill> Bills { get; set; } 
        public DbSet<Book> Books { get; set; } 
        public DbSet<Copy> Copies { get; set; } 
        public DbSet<Loan> Loans { get; set; } 
        public DbSet<User> Users { get; set; }


    }
}
