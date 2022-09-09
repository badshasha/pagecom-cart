using MediatR;
using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.contract.UserContract;
using pagecom.cart.app.DTO.CartBookDTO;
using pagecom.cart.app.Features.CartFeatures.Request;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Handler.Request;

public class GetUserCartSelectedBooksRequestHandler : IRequestHandler<GetUserCartSelectedBooksRequest,List<CartBookDto>>
{
    private readonly IcartBookRepository _cartBookRepository;
    

    public GetUserCartSelectedBooksRequestHandler(IcartBookRepository cartBookRepository)
    {
        _cartBookRepository = cartBookRepository;
        
    }
    
    
    public async Task<List<CartBookDto>> Handle(GetUserCartSelectedBooksRequest request, CancellationToken cancellationToken)
    {
        var books = await this._cartBookRepository.GetCartBooksFromUserCartId(request.id);
        return books;
    }
}