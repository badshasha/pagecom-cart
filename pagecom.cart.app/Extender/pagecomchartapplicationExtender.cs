using System.Reflection;
using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace pagecom.cart.app.Extender;

public  static class pagecomchartapplicationExtender
{
    public static IServiceCollection pagecomachartApplicationExtender(this IServiceCollection service)
    {
        service.AddMediatR(Assembly.GetExecutingAssembly());
        return service;
    }
}