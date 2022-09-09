using pagecom.cart.app.contract.UserContract;
using pagecom.cart.app.DTO.CartDTO;
using pagecom.cart.app.DTO.UseDTO;
using pagecom.cart.data.databaseConfiguration;
using pagecom.cart.domain;

namespace pagecom.cart.data.Service;

public class UserService : IUserRepository
{
    private readonly ApplicationDbContext _context;


    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<User?> GetUserFromId(string id)
    {
        var user = this._context.Users.FirstOrDefault(u => u.UserId == id);
        return Task.FromResult(user);
    }

    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }


    public Task<UserDTOForEmail?> GetUserNonDeliverdForEmail(User user)
    {
        var userCarts = this._context.Users.Where(u => u.UserId == user.UserId).Select(n => new UserDTOForEmail()
        {
            UserId = n.UserId,
            UserName = n.UserName,
            Email = n.Email,
            Role = n.Role,
            carts = n.Carts!.Where(c => c.Delivery == false).ToList()
        }).FirstOrDefault();

        return Task.FromResult(userCarts);
    }

    public Task<UserDTO?> GetUserNonDeliverdCart(User user)
    {
        var userCarts = this._context.Users.Where(u => u.UserId == user.UserId).Select(n => new UserDTO()
        {
            UserId = n.UserId,
            UserName = n.UserName,
            Email = n.Email,
            Role = n.Role,
            carts = n.Carts!.Where(c => c.Delivery == false).Select(x => new CartDTO()
            {
                Id = x.Id,
                Delivery = x.Delivery,
                AddDateTime = x.AddDateTime,

            }).ToList()
        }).FirstOrDefault();

        return Task.FromResult(userCarts);

    }



    public Task<UserDTO> GetUserAllCart(string id)
    {
        var userCarts = this._context.Users.Where(u => u.UserId == id).Select(n => new UserDTO()
        {
            UserId = n.UserId,
            UserName = n.UserName,
            Email = n.Email,
            Role = n.Role,
            carts = n.Carts!.Select(x => new CartDTO()
            {
                Id = x.Id,
                Delivery = x.Delivery,
                AddDateTime = x.AddDateTime,

            }).ToList()
        }).FirstOrDefault();

        return Task.FromResult(userCarts!);
    }


    public Task<User> Create(UserDTO userobj)
    {
        var user = new User()
        {
            UserId = userobj.UserId,
            UserName = userobj.UserName,
            Email = userobj.Email,
            Role = userobj.Role,
            Carts = null
        };
        this._context.Users.Add(user);
        this._context.SaveChanges();
        return Task.FromResult(user);
    }
}