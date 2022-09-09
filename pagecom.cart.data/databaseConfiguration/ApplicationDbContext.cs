using Microsoft.EntityFrameworkCore;
using pagecom.cart.domain;

namespace pagecom.cart.data.databaseConfiguration;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart_books>()
            .HasOne(a => a.Book)
            .WithMany(b => b.CartBooks)
            .HasForeignKey(c => c.BookId);
        
        
        modelBuilder.Entity<Cart_books>()
            .HasOne(a => a.Cart)
            .WithMany(b => b.CartBooks)
            .HasForeignKey(c => c.CartId);
    }


    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Cart_books> CartBooks { get; set; }


}