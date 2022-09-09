using pagecom.cart.app.DTO.ResponseDTO;

namespace pagecom.infastructure;

public class ResponseCreating
{
    
    public static ResponseDTO GetResponse(object? information, List<string>? error = null)
    {
        var temp = new ResponseDTO()
        {
            Result = information,
            Error = error,
            IsSuccess = information != null ? true : false

        };
        return temp;
    }
}