using MediatR;
using pagecom.cart.app.contract.UserContract;
using pagecom.cart.app.DTO.UseDTO;
using pagecom.cart.app.Features.CartFeatures.Request;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Handler.Request;

public class GetCurrentUserCartRequestHandler : IRequestHandler<GetCurrentUserCartRequest,UserDTO>
{
    private readonly IUserRepository _userRepository;

    public GetCurrentUserCartRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDTO> Handle(GetCurrentUserCartRequest request, CancellationToken cancellationToken)
    {
        
        var user = await this._userRepository.GetUserFromId(request.id);
        if (user != null)
        {
            var value = await this._userRepository.GetUserNonDeliverdCart(user);
            return value;
        }

        return new UserDTO();

    }
}