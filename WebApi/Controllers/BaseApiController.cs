using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
//[Route("api/{v:apiversion}/[controller]")]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{

}
