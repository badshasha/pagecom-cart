using MediatR;
using pagecom.cart.app.contract.BookContract;
using pagecom.cart.app.Features.CartFeatures.Request;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Handler.Request;

public class GetCartBookDetailRequestHandler : IRequestHandler<GetCartBookDetailRequest,Book>
{
    private readonly IBookRepository _bookRepository;

    public GetCartBookDetailRequestHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<Book> Handle(GetCartBookDetailRequest request, CancellationToken cancellationToken)
    {
        var bookinfo = await this._bookRepository.Get(request.id);
        return bookinfo;
    }
}