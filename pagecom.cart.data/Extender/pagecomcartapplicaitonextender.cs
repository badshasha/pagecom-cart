using System.Diagnostics;
using System.Reflection;
using MassTransit;
using MassTransit.MultiBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pagecom.cart.app.contract;
using pagecom.cart.app.contract.BookContract;
using pagecom.cart.app.contract.CartBookService;
using pagecom.cart.app.contract.UserContract;
using pagecom.cart.data.databaseConfiguration;
using pagecom.cart.data.Service;

namespace pagecom.cart.data.Extender;

public static class pagecomcartapplicaitonextender
{
    public static IServiceCollection pagecomcartApplicationExtenderclass(this IServiceCollection service,IConfiguration configuration)
    {
        service.AddScoped<IBookRepository, Bookservice>();
        service.AddScoped<IUserRepository, UserService>();
        service.AddScoped<IcartBookRepository, CartBookService>();
        service.AddScoped<ICartRepository, CartService>();
        

        service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")
        ));
        
        
        // mapping profile inject 
        service.AddAutoMapper(Assembly.GetExecutingAssembly());


        // rabbit mq inject 
        service.AddMassTransit(x =>
        {
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            }));
        });

        
        return service;
    }
}