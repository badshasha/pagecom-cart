using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.DTO.CartBookDTO;
using pagecom.cart.app.DTO.CartDTO;
using pagecom.cart.data.databaseConfiguration;
using pagecom.cart.domain;

namespace pagecom.cart.data.Service;

public class CartBookService : IcartBookRepository
{
    private readonly ApplicationDbContext _context;

    public CartBookService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public Task<Cart_books> Add(Book book,CartDTO selectedUserCart,int Quentity)
    {
        var newcartBooks = new Cart_books()
        {
            BookId = book.Id,
            CartId = selectedUserCart.Id,
            Quentity = Quentity
        };

        this._context.CartBooks.Add(newcartBooks);
        this._context.SaveChanges();
        return Task.FromResult(newcartBooks);
    }

    public Task<Cart_books> GetFromId(int id)
    {
        var cartBooks = this._context.CartBooks.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(cartBooks!);
    }

    public Task<List<Cart_books>> GetFromUserCart(CartDTO? selectedusercart)
    {
        List<Cart_books> CartBookList = this._context.CartBooks.Where(c => c.CartId == selectedusercart!.Id).ToList();
        return Task.FromResult(CartBookList);
    }

    public Task<List<CartBookDto>> GetCartBooksFromUserCartId(int id)
    {
        List<CartBookDto> cartBooksList= this._context.CartBooks.Where(c => c.CartId == id).Select(n => new CartBookDto()
        {
            Id = n.Id,
            BookId = n.BookId,
            CartId = n.CartId,
            BookName =  this._context.Books.FirstOrDefault(x => x.Id == n.BookId)!.Name,
            Quentity = n.Quentity
        }).ToList();
        return Task.FromResult(cartBooksList);
    }

    public Task<Cart_books> Update(Cart_books cartBooksobj, int Quentiy)
    {
        cartBooksobj.Quentity += Quentiy;
        this._context.CartBooks.Update(cartBooksobj);
        this._context.SaveChanges();
        return Task.FromResult(cartBooksobj);
    }

    public async Task<bool> DeleteFromCartBook(int id)
    {
        var cartBookObj = await this.GetFromId(id);
        if (cartBookObj != null)
        {
            this._context.CartBooks.Remove(cartBookObj);
            this._context.SaveChanges();
            return true;
        }

        return false;
    }
}