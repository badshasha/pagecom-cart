using AutoMapper;
using pagecom.cart.app.DTO.CartBookDTO;
using pagecom.cart.app.DTO.CartDTO;

namespace pagecom.cart.data.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DoneCartDTO,common.DoneCartDTO>().ReverseMap();
        CreateMap<CartBookDto, common.CartBookDto>().ReverseMap();
    }
}