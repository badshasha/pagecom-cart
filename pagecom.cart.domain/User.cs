using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pagecom.cart.domain.BaseDomainInformation;

namespace pagecom.cart.domain;

public class User 
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string UserId { get; set; }
    
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } = "customer";


    public virtual List<Cart>? Carts { get; set; }
    
}