using pagecom.cart.app.DTO;
using pagecom.cart.app.DTO.BookDTO;
using pagecom.cart.app.DTO.CartDTO;
using pagecom.cart.domain;

namespace pagecom.cart.app.contract;

public interface ICartRepository
{
    // Task<Cart> GetCartFromUserId(string userId);
    // Task<Cart> AddNewProductToCart(BookDTO bookInfo);
    // Task<Cart> RemoveBookFromCart(int cartbookId);
    // Task<Cart> DiliveryCart(); // todo


    Task<Cart> AddItemToCart(CartRequesestInfomationDTO info);
    Task<List<Cart>> GetUserAllCart(User user); // all cart with diliver and not deliverd 
    Task<Cart> GetUserCurrentCart(User user); // provide current not deliver cart 
    Task<bool> doneCart(DoneCartDTO cartInfo); // continue purches cart 
}