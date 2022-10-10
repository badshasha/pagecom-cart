using MediatR;
using Microsoft.AspNetCore.Mvc;
using pagecom.cart.app.contract;
using pagecom.cart.app.contract.BookContract;
using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.contract.UserContract;
using pagecom.cart.app.DTO;
using pagecom.cart.app.DTO.CartDTO;
using pagecom.cart.app.DTO.ResponseDTO;
using pagecom.cart.app.Features.CartFeatures.Request;
using pagecom.cart.app.Features.CartFeatures.Request.command;
using pagecom.infastructure;

namespace pagecom.test.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CartController : Controller
{
    private readonly IMediator _meadiator;
    private readonly ICartRepository _cartservice;
    private readonly IUserRepository _userRepository;
    private readonly IcartBookRepository _cartBookRepository;
    private readonly IBookRepository _bookRepository;
    private ResponseDTO _response;

    public CartController(
        IMediator _meadiator,
        ICartRepository cartservice,
        IUserRepository userRepository,
        IcartBookRepository cartBookRepository,
        IBookRepository bookRepository
        )
    {
        this._meadiator = _meadiator;
        _cartservice = cartservice;
        _userRepository = userRepository;
        _cartBookRepository = cartBookRepository;
        _bookRepository = bookRepository;


        _response = new ResponseDTO();

    }
    
    // GET
    [HttpGet]
    public IActionResult Index() // we dont need this 
    {
        return Ok("working");
    }
    
    // post
    [HttpPost]
    public async Task<ResponseDTO> GetCart([FromBody] CartRequesestInfomationDTO info) // mediator ok
    {
        // checking user
        try
        {
            var value = await this._cartservice.AddItemToCart(info); // todo add mediator
            this._response = ResponseCreating.GetResponse(true);
        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;
    }

    [HttpGet("allcart/{id}")]
    public async Task<ResponseDTO> GetUserAllCart(string id) 
    {
       
        try
        {
            var usercarts = await this._meadiator.Send(new GetUserAllCartRequest(id));
            this._response = ResponseCreating.GetResponse(usercarts);

        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;

    }


    [HttpGet("currentcart/{id}")]
    public async Task<ResponseDTO> GetUserCurrentCart(string id) 
    {
        
        try
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------| CHECK CURRENT CART |--------------------------------------------");
            
            
            var usercarts = await this._meadiator.Send(new GetCurrentUserCartRequest(id));
            this._response = ResponseCreating.GetResponse(usercarts);

        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;
    }

    [HttpGet("getBooks/{id}")]
    public async Task<ResponseDTO> GetUserCartSelectedBooks(int id) // provide selected cart product [book]
    {
        // var books = await this._cartBookRepository.GetCartBooksFromUserCartId(id);
        // return Ok(books);
        
        
        try
        {
            var usercarts = await this._meadiator.Send(new GetUserCartSelectedBooksRequest(id)); // get all the products 
            this._response = ResponseCreating.GetResponse(usercarts);

        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;
        
    }

    [HttpGet("getBookinfo/{id}")]
    public async Task<ResponseDTO> GetCartBookDetail(int id) // provide infomation about the book [selected --> cart ---> book info] 
    {
        // var bookinfo = await this._bookRepository.Get(id);
        // return Ok(bookinfo);
        try
        {
            var usercarts = await this._meadiator.Send(new GetCartBookDetailRequest(id)); // get all the products 
            this._response = ResponseCreating.GetResponse(usercarts);

        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;
        
        
        
        
    }

    [HttpDelete("{id}")]
    public async Task<ResponseDTO> DeleteCartProdcut(int id) 
    {
        // var success = await this._cartBookRepository.DeleteFromCartBook(id);
        // return Ok(success);
        
        try
        {
            var usercarts = await this._meadiator.Send(new DeleteCartProductCommand(id)); // get all the products 
            this._response = ResponseCreating.GetResponse(usercarts);

        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;
        
        
        
    }

    [HttpPost("done")]
    public async Task<ResponseDTO> DoneCart([FromBody] DoneCartDTO donecartinfo)
    {
        try
        {
           var usercarts = await this._meadiator.Send(new DoneCartCommandRequest(donecartinfo)); // get all the products 
           this._response = ResponseCreating.GetResponse(usercarts);
           

        }
        catch (Exception ex)
        {
            this._response = ResponseCreating.GetResponse(null, new List<string>() { ex.ToString() });
        }

        return this._response;
    }


}