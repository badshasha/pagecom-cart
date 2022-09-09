using MediatR;
using pagecom.cart.app.DTO;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Request.command;

public record GetCartCommand(CartRequesestInfomationDTO info):IRequest<Cart>;