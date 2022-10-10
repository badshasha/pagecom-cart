using AutoMapper;
using MassTransit;
using MediatR;
using pagecom.cart.app.contract;
using pagecom.cart.app.contract.BookContract;
using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.DTO.EmailDTO.cs;
using pagecom.cart.app.Features.CartFeatures.Request.command;
using pagecom.cart.domain;
using pagecom.common;

namespace pagecom.cart.app.Features.CartFeatures.Handler.command;

public class DoneCartCommandRequestHandler : IRequestHandler<DoneCartCommandRequest,bool>
{
    private readonly ICartRepository _cartRepository;
    private readonly IcartBookRepository _cartBookservice;
    private readonly IBookRepository _bookRepo;
    private readonly IBus _bus;
    private readonly IMapper _mapper;

    public DoneCartCommandRequestHandler(
        ICartRepository cartRepository,
        IcartBookRepository cartBookservice,
        IBookRepository bookRepo,
        IBus bus,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _cartBookservice = cartBookservice;
        _bookRepo = bookRepo;
        _bus = bus;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(DoneCartCommandRequest request, CancellationToken cancellationToken)
    {
        // cart purches done informatino changer 
        // adding this informaition to database 
      // todo uncomment bellow line of code 
      // var donecartStatus  =  await this._cartRepository.doneCart(request.cartInfo);

        bool donecartStatus = true;
        if (donecartStatus)
        {
            // email send
            // this thing should be event 
        
            // get all the books for the cart id
        
            var books = await this._cartBookservice.GetCartBooksFromUserCartId(request.cartInfo.CartId);
            double? price = 0 ;
            foreach (var entity in books) // calculate the price 
            {
                // price calculate 
                var book =await this._bookRepo.Get(entity.BookId); // get individual book information 
                var tempPrice = entity.Quentity * book.Price;
        
                if (tempPrice != null)
                {
                    price += tempPrice;
                }
            }

            
            
            var emailInfomation = new EmailInfomation()
            {
                info =this._mapper.Map<common.DoneCartDTO>(request.cartInfo),
                bookList = this._mapper.Map<List<common.CartBookDto>>(books),
                Price = price
            };
            
            // send information to rabbit mq 
            Console.WriteLine("message send to RabbitMQ");
            var url = new Uri("rabbitmq://localhost/pagecom"); // assume this thing is a exchanger name
            var endpint = await this._bus.GetSendEndpoint(url);

            // var productInformation =new P()
            // {
            //     Name = "iphone",
            // };
            
            await endpint.Send(emailInfomation);
        
            return true;
        }
        
        return false;
   
    }
}