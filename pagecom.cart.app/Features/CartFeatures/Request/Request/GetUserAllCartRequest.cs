using MediatR;
using pagecom.cart.app.DTO.ResponseDTO;
using pagecom.cart.app.DTO.UseDTO;

namespace pagecom.cart.app.Features.CartFeatures.Request;

public record GetUserAllCartRequest(string id):IRequest<UserDTO>;