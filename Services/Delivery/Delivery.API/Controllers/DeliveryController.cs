using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Route("[controller]")]
public class DeliveryController : ControllerBase
{
    private readonly ILogger<DeliveryController> _logger;

    public DeliveryController(ILogger<DeliveryController> logger)
    {
        _logger = logger;
    }
}