using Microsoft.AspNetCore.Mvc;
using Sinqia.Bofa.Service.Singleton;

namespace Sinqia.Bofa.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingletonController : ControllerBase
    {

        [HttpGet(Name = "CreateSingletonInstance")]
        public IActionResult Create()
        {
            var instances = SingletonService.Instance.CreateInstanceOfSingleton();

            return Ok(ReferenceEquals(instances[0], instances[1]));
        }
    }
}
