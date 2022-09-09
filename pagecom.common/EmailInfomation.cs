namespace pagecom.common;

public class EmailInfomation
{
    public DoneCartDTO info { get; set; }
    public List<CartBookDto> bookList { get; set; }
    public Double? Price { get; set; } = 0;
}