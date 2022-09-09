using MediatR;
using pagecom.cart.app.DTO.CartDTO;

namespace pagecom.cart.app.Features.CartFeatures.Request.command;

public record DoneCartCommandRequest(DoneCartDTO cartInfo):IRequest<bool>;