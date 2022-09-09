using MediatR;

namespace pagecom.cart.app.Features.CartFeatures.Request.command;

public record DeleteCartProductCommand(int id) : IRequest<bool>;

    
