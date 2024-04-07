using Microsoft.AspNetCore.Mvc;

namespace SedisBackend.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
