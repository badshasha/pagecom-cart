using MediatR;
using pagecom.cart.app.contract;
using pagecom.cart.app.Features.CartFeatures.Request.command;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Handler.command;

public class GetCartCommandHandler : IRequestHandler<GetCartCommand,Cart>
{
    private readonly ICartRepository _cartRepository;

    public GetCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    
    public async Task<Cart> Handle(GetCartCommand request, CancellationToken cancellationToken)
    {
        var value =  await this._cartRepository.AddItemToCart(request.info);
        return value;
    }
}