using MediatR;
using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.Features.CartFeatures.Request.command;

namespace pagecom.cart.app.Features.CartFeatures.Handler.command;

public class DeleteCartProductCommandHandler : IRequestHandler<DeleteCartProductCommand,bool>
{
    private readonly IcartBookRepository _cartBookRepository;

    public DeleteCartProductCommandHandler(IcartBookRepository cartBookRepository)
    {
        _cartBookRepository = cartBookRepository;
    }


    public async Task<bool> Handle(DeleteCartProductCommand request, CancellationToken cancellationToken)
    {
        var success = await this._cartBookRepository.DeleteFromCartBook(request.id);
        return success;
    }
}