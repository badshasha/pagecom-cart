using MediatR;
using pagecom.cart.app.DTO.CartBookDTO;
using pagecom.cart.domain;

namespace pagecom.cart.app.Features.CartFeatures.Request;

public record GetUserCartSelectedBooksRequest(int id) : IRequest<List<CartBookDto>>;