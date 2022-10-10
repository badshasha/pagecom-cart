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

        if (DbInfo.HOST != null)
        {

            string connectionString;
            if (DbInfo.AZURE_ENVIRONMENT) // in the azure environment [  azure sql server  ]
            {
                connectionString = 
                    $"Server=tcp:{DbInfo.HOST},{DbInfo.PORT};Initial Catalog={DbInfo.DATABASE};Persist Security Info=False;User ID={DbInfo.USER};Password={DbInfo.PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                Console.WriteLine("azure connection establish");
            }
            else  // local production environment testing 
            {
                connectionString =
                    $"Data Source={DbInfo.HOST},{DbInfo.PORT};Initial Catalog={DbInfo.DATABASE};User ID={DbInfo.SA};Password={DbInfo.PASSWORD}";
            }

        

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(connectionString);
            
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                connectionString
                ));
        }
        else
        {
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));
        }

      
        
        
        // mapping profile inject 
        service.AddAutoMapper(Assembly.GetExecutingAssembly());


        // rabbit mq inject 
        service.AddMassTransit(x =>
        {
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                // config.Host("localhost", h =>
                // {
                //     h.Username("guest");
                //     h.Password("guest");
                // }); // local environment 
                
                // config.Host(DbInfo.RABBIT , h =>
                // {
                //     h.Username("guest");
                //     h.Password("guest");
                // }); // docker environment 
                
                config.Host( DbInfo.RABBIT ,"/" , h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                }); // for kubernetes 
                
                
            }));
        });

        
        return service;
    }
}