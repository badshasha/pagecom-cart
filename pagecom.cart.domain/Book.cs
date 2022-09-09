using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pagecom.cart.domain.BaseDomainInformation;

namespace pagecom.cart.domain;

public class Book 
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    
    public String Name { get; set; }
    public String Description { get; set; }
    public Double Price { get; set; }
    
    // relationship
    public List<Cart_books> CartBooks { get; set; }
}