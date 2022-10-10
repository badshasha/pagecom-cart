using pagecom.cart.app.contract.BaseService;
using pagecom.cart.app.DTO.UseDTO;
using pagecom.cart.domain;

namespace pagecom.cart.app.contract.UserContract;

// public interface UserRepository : IGenericBaseService<User>
// {
//     
// }

public interface IUserRepository
{
    Task<User> GetUserFromId(string id);
    Task<List<User>> GetAllUsers();
    Task<User> Create(UserDTO userobj);
    Task<UserDTO?> GetUserNonDeliverdCart(User user); // current user

    Task<UserDTO> GetUserAllCart(string id); // user for browse history 
    
    
    
    // this thing use for get informatnio for email 
    Task<UserDTOForEmail?> GetUserNonDeliverdForEmail(User user);
}