using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [HttpGet]
    public IActionResult GET()
    {
        _logger.LogInformation("Retornando la lista de HelloWord");
        return Ok(helloWorldService.GetHelloWorld());
    }

}