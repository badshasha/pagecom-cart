using MediatR;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Request;

public record GetCartBookDetailRequest(int id):IRequest<Book>;