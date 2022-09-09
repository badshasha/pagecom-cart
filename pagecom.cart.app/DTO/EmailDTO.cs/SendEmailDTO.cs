using pagecom.cart.app.DTO.CartBookDTO;
using pagecom.cart.app.DTO.CartDTO;

namespace pagecom.cart.app.DTO.EmailDTO.cs;

public class SendEmailDTO
{
    public DoneCartDTO info { get; set; }
    public List<CartBookDto> bookList { get; set; }
    public Double? Price { get; set; } = 0;
}