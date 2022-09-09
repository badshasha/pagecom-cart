using MediatR;
using pagecom.cart.app.DTO.UseDTO;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Request;

public record GetCurrentUserCartRequest(string id):IRequest<UserDTO>;