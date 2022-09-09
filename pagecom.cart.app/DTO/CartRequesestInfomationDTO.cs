using pagecom.cart.app.DTO.UseDTO;

namespace pagecom.cart.app.DTO;

public class CartRequesestInfomationDTO
{
   public UserDTO userInfo { get; set; }
   public BookDTO.BookDTO bookInfo { get; set; }

   public int Quenity { get; set; } = 1;
}