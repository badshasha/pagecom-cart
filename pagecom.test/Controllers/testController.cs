using Microsoft.AspNetCore.Mvc;


using MassTransit;
using Microsoft.AspNetCore.Mvc;
using pagecom.common;


namespace pagecom.test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class testController : Controller
{
    private readonly IBus _bus;


    public testController(IBus bus)
    {
        _bus = bus;
    }
    // GET
    [HttpPost]
    public async Task<IActionResult> PostMessage()
    {
        var productInformation =new P()
        {
            Name = "iphone",
        };

        var url = new Uri("rabbitmq://localhost/pagecom");
        var endpint = await this._bus.GetSendEndpoint(url);
        await endpint.Send(productInformation);
        return Ok("successfully send ");
    }
}

