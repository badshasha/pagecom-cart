using MediatR;
using pagecom.cart.app.contract.UserContract;
using pagecom.cart.app.DTO.UseDTO;
using pagecom.cart.app.Features.CartFeatures.Request;

namespace pagecom.cart.app.Features.CartFeatures.Handler.Request;

public class GetUserAllCartRequestHander : IRequestHandler<GetUserAllCartRequest,UserDTO>
{
    private readonly IUserRepository _userRepository;

    public GetUserAllCartRequestHander(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<UserDTO> Handle(GetUserAllCartRequest request, CancellationToken cancellationToken)
    { 
        var value = await this._userRepository.GetUserAllCart(request.id);
        return value;
    }
}