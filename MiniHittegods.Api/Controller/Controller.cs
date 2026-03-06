using Microsoft.AspNetCore.Mvc;

namespace MiniHittegods.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[] { "Sample data" });
    }
}
