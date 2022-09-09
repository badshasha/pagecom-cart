using pagecom.cart.domain.BaseDomainInformation;

namespace pagecom.cart.domain;

public class Cart_books : BaseDomainInfo
{
    public int CartId { get; set; }
    public virtual Cart Cart { get; set; }

    public int BookId { get; set; }
    public virtual Book Book { get; set; }

    public int? Quentity { get; set; } = null;

}