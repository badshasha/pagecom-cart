using Microsoft.EntityFrameworkCore;
using pagecom.cart.data.databaseConfiguration;
using pagecom.cart.domain;

namespace pagecom.test.databaseprepreration;

public class PrepData
{
    public static async void DatabaseCreating(IApplicationBuilder app)
    {
        using (var servicescope = app.ApplicationServices.CreateScope())
        {
           await SeedInformation(servicescope.ServiceProvider.GetService<ApplicationDbContext>()!);
        }
        
        
    }

    private static async Task SeedInformation(ApplicationDbContext context)
    {
        Console.WriteLine("apply migrations [+++]");
        context.Database.Migrate();

        if (!context.Books.Any())
        {
            Console.WriteLine("adding books to the table [++++++] ");
            await context.Books.AddRangeAsync(
                new Book()
                {
                    Id = 1,
                    Name = "test book 1",
                    Description = "book user for initialize book table"
                }
            );
            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("already contain book table ");
        }

        if (!context.Users.Any()!)
        {
            Console.WriteLine("user testing migrations [++++ ] ");
            await context.Users.AddRangeAsync(
                    new User()
                    {
                        UserId = "test_id",
                        Email = "testing email",
                        Role = "admin_test",
                        UserName = "test_name"
                        
                    }
                
                );
            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("already contain user table ");
        }

        if (!context.Carts.Any())
        {
            Console.WriteLine("adding cart table [+++++] ");
            var cart = new Cart()
            {
                Price = 100,
                userID = "test_id",
                Delivery = false
            };
            await context.Carts.AddRangeAsync(
                cart
            );
            await context.SaveChangesAsync();


            Console.WriteLine("adding cart_book details ");
            
            await context.CartBooks.AddRangeAsync(
                    new Cart_books()
                    {
                        BookId = 1,
                        CartId = cart.Id,
                        Quentity = 1
                    }
                
                );

            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("already contain cart and cartbook table ");
        }
    }

}