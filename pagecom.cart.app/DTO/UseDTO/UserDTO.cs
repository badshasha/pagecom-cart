using pagecom.cart.domain;

namespace pagecom.cart.app.DTO.UseDTO;

public class UserDTO // 
{
    public string UserId { get; set; }
    
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public List<CartDTO.CartDTO> carts { get; set; }
}