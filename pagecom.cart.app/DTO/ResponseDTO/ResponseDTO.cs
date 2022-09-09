namespace pagecom.cart.app.DTO.ResponseDTO;

public class ResponseDTO
{
    public bool IsSuccess { get; set; } = true;
    public object? Result { get; set; }
    public List<string>? Error { get; set; }
    public string Message { get; set; } = "";
}