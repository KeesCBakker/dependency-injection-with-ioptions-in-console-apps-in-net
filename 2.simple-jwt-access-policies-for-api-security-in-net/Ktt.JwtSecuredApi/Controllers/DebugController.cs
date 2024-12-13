using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/whoami")]
public class DebugController(IUserNameAccessor userNameAccessor) : ControllerBase
{
    [HttpGet]
    public IActionResult WhoAmI()
    {
        return Ok(new
        {
            userNameAccessor.UserName,
            userNameAccessor.Issuer
        });
    }
}
