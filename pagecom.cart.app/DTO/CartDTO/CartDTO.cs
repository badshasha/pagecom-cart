using pagecom.cart.domain;

namespace pagecom.cart.app.DTO.CartDTO;

public class CartDTO
{
    public int Id { get; set; }
    public DateTime AddDateTime { get; set; }

    public bool Delivery { get; set; } 

    public string userID { get; set; } // todo may be an issue 
}