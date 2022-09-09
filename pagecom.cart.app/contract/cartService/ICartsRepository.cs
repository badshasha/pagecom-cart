using pagecom.cart.domain;

namespace pagecom.cart.app.contract.cartService;

public interface ICartsRepository
{
    Task<Cart> AddNewCart(User info);
    
}