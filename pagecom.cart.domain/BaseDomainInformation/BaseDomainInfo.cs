namespace pagecom.cart.domain.BaseDomainInformation;

public class BaseDomainInfo
{
    public int Id { get; set; }
    public DateTime AddDateTime { get; set; } = DateTime.Now;
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;
}

