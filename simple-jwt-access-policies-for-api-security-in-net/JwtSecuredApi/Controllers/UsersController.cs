using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "users")]
    public IActionResult GetUsers()
    {
        return Ok("Access granted to users.");
    }
}
