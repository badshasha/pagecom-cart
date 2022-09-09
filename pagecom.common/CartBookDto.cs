namespace pagecom.common;

public class CartBookDto
{
    public int Id { get; set; }
    public DateTime AddDateTime { get; set; } = DateTime.Now;
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    
    public int CartId { get; set; }
    

    public int BookId { get; set; }
    public string BookName { get; set; }

    public int? Quentity { get; set; } 
}