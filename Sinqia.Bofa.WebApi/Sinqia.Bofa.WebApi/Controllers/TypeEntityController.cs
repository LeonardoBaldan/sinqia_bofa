using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sinqia.Bofa.Domain;
using Sinqia.Bofa.Factory.Entity;
using Sinqia.Bofa.Factory.Entity.Interface;
using Sinqia.Bofa.WebApi.Models;

namespace Sinqia.Bofa.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeEntityController : ControllerBase
    {
        private readonly ILogger<TypeEntityModel> _logger;
        private readonly IMapper _mapper;

        public TypeEntityController(IMapper mapper, ILogger<TypeEntityModel> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(Name = "GetTypeEntity")]
        public IActionResult GetTypeEntity([FromBody] TypeEntityViewModel p)
        {
            var entity = _mapper.Map<TypeEntityViewModel>(p);
            ITypeEntity typeEntity = EntityTypeFactory.CreateTypeEntity(entity.NameEntityType);

            try
            {
                return Ok(typeEntity.GetTypeEntity());
            }
            catch
            {
                return BadRequest(typeEntity.GetTypeEntity());
            }            
        }
    }
}
