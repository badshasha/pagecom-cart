using System.Net;
using pagecom.cart.app.contract;
using pagecom.cart.app.contract.BookContract;
using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.contract.UserContract;
using pagecom.cart.app.DTO;
using pagecom.cart.app.DTO.BookDTO;
using pagecom.cart.app.DTO.CartDTO;
using pagecom.cart.app.DTO.UseDTO;
using pagecom.cart.data.databaseConfiguration;
using pagecom.cart.domain;

namespace pagecom.cart.data.Service;

public class CartService : ICartRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IBookRepository _bookservice;
    private readonly IUserRepository _userService;
    private readonly IcartBookRepository _cartBookservice;

    public CartService(ApplicationDbContext context,IBookRepository bookservice,IUserRepository userService,IcartBookRepository cartBookservice)
    {
        _context = context;
        _bookservice = bookservice;
        _userService = userService;
        _cartBookservice = cartBookservice;
    }

    Task<Cart> AddNewCart(User user)
    {
        var newcart = new Cart()
        {
            userID = user.UserId,
            Delivery = false,
        };

        this._context.Carts.Add(newcart); // change to async
        this._context.SaveChanges();
        return Task.FromResult(newcart);
    }

    public async Task<Cart> AddItemToCart(CartRequesestInfomationDTO info)
    {
        // check book is there 
        //var book = this._context.Books.FirstOrDefault(b => b.Id == info.bookInfo.Id);
        var book = await this._bookservice.Get(info.bookInfo.Id);
        if (book == null) // book is not exist
        {
            //impliment mapping facility 
            book = new Book()
            {
                Id = info.bookInfo.Id,
                Description = info.bookInfo.Description,
                Name = info.bookInfo.Name,
                Price = info.bookInfo.Price
            };
            

            book = await this._bookservice.Create(book);
            
            Console.WriteLine("[+]  book added to database");
        }
        // book exist but update required 
        else if (book.Price != info.bookInfo.Price)
        {
            // update book information 
            book.Price = info.bookInfo.Price;
            await this._bookservice.Update(book);
            
            Console.WriteLine("[+] book update new price added");
        }
      
        
        
        
        // check user existing on the table 
       // var user = this._context.Users.FirstOrDefault(u => u.UserId == info.userInfo.UserId);
       var user = await this._userService.GetUserFromId(info.userInfo.UserId);
        if (user == null) // if user not add new user 
        {
            // mapping facility requeird    
            // user = new User()
            // {
            //     UserId = info.userInfo.UserId,
            //     UserName = info.userInfo.UserName,
            //     Email = info.userInfo.Email,
            //     Role = info.userInfo.Role,
            //     Carts = null
            // };
            // this._context.Users.Add(user);
            // this._context.SaveChanges();

            user = await this._userService.Create(info.userInfo);

        }
        
        // get user carts // still not delivered [delivered :false] 
        // var userCarts = this._context.Users.Where(u => u.UserId == user.UserId).Select(n => new UserDTO()
        // {
        //     UserId = n.UserId,
        //     UserName = n.UserName,
        //     Email = n.Email,
        //     Role = n.Role,
        //     carts = n.Carts.Where(c => c.Delivery == false).Select(x => new CartDTO()
        //     {
        //         Id = x.Id,
        //         Delivery = x.Delivery,
        //         AddDateTime = x.AddDateTime,
        //
        //     }).ToList()
        // }).FirstOrDefault();


        var userCarts = await this._userService.GetUserNonDeliverdCart(user);
        
        
        // if user havent got any cart information
        if (!userCarts.carts.Any())
        {
            // create cart 
            // var newcart = new Cart()
            // {
            //     userID = user.UserId,
            //     Delivery = false,
            // };
            //
            // this._context.Carts.Add(newcart); // change to async
            // this._context.SaveChanges();


            var newcart = await this.AddNewCart(user);
            
            
            // add that cart to user information
            // first convert it to dto
            var cartDtoInformation = new CartDTO()
            {
                Delivery = newcart.Delivery,
                Id = newcart.Id,
                userID = newcart.userID
            };
            
            userCarts.carts.Add(cartDtoInformation); // [add dto to filterd list ] 

        }
        
        // get all product for the cart_BOOK TABLE 
        // because if the product exist we need to update quentity not add product 
        var selectedUserCart = userCarts.carts.FirstOrDefault();
        
        //List<Cart_books> CartBookList = this._context.CartBooks.Where(c => c.CartId == selectedUserCart!.Id).ToList();
        List<Cart_books> CartBookList = await this._cartBookservice.GetFromUserCart(selectedUserCart);
        var value =CartBookList.FirstOrDefault(q => q.BookId == book.Id);
        if (value != null)
        {
            // update that quenitty 
            // value.Quentity += info.Quenity;
            // this._context.CartBooks.Update(value);
            // this._context.SaveChanges();

            value = await this._cartBookservice.Update(value, info.Quenity);
        }
        else
        {
            // var newcartBooks = new Cart_books()
            // {
            //     BookId = book.Id,
            //     CartId = selectedUserCart.Id,
            //     Quentity = info.Quenity
            // };
            //
            // this._context.CartBooks.Add(newcartBooks);
            // this._context.SaveChanges();

            await this._cartBookservice.Add(book, selectedUserCart, info.Quenity);
        }


        return new Cart();


    }


    public async Task<bool> doneCart(DoneCartDTO cartInfo)
    {
        var user =await this._userService.GetUserFromId(cartInfo.userId);
        if (user != null)
        {
            // var cart = user.Carts.FirstOrDefault();
            // get user non deliverd cart 
            var value =await this._userService.GetUserNonDeliverdForEmail(user);
            var cart = value!.carts.FirstOrDefault();
            // check that id related with the provided id [not mandotory use for secutiry option]
            
            if (cart!.Id == cartInfo.CartId) // if the selecte cart is last cart 
            {
                cart.Delivery = true;
                this._context.Carts.Update(cart);
                this._context.SaveChanges();

                return true;
                
            }     
            
        }
        return false;

    }


    public Task<List<Cart>> GetUserAllCart(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> GetUserCurrentCart(User user)
    {
        throw new NotImplementedException();
    }

  
}