using pagecom.cart.domain;

namespace pagecom.cart.app.DTO.UseDTO;

public class UserDTOForEmail
{
    public string UserId { get; set; }
    
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public List<Cart> carts { get; set; }
}