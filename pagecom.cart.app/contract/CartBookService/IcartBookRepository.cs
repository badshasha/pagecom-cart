using pagecom.cart.app.DTO.CartBookDTO;
using pagecom.cart.app.DTO.CartDTO;
using pagecom.cart.domain;

namespace pagecom.cart.app.contract.CartBookService;

public interface IcartBookRepository
{
    public Task<Cart_books> Add(Book book, CartDTO selectedUserCart, int Quentity);

    public Task<Cart_books> GetFromId(int id);
    Task<List<Cart_books>>GetFromUserCart(CartDTO? selectedusercart);

    Task<List<CartBookDto>> GetCartBooksFromUserCartId(int id);

    Task<Cart_books> Update(Cart_books cartBooksobj, int Quentiy);

    Task<bool> DeleteFromCartBook(int id);
    

}