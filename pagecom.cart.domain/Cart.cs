using pagecom.cart.domain.BaseDomainInformation;

namespace pagecom.cart.domain;

public class Cart : BaseDomainInfo
{

    public bool Delivery { get; set; } = false;
    
    public string userID { get; set; }
    public virtual User User { get; set; }

    public List<Cart_books> CartBooks { get; set; }

    public double? Price { get; set; } = null; // sum of all sub product 

}