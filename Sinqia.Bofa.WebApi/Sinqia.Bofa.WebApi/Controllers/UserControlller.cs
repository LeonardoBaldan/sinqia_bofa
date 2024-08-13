using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sinqia.Bofa.Domain;
using Sinqia.Bofa.Service.Validation;
using Sinqia.Bofa.Service.Validation.Interface;
using Sinqia.Bofa.WebApi.Models;

namespace Sinqia.Bofa.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserModel> _logger;
        private readonly IMapper _mapper;
        private readonly IValidationUserService _validationUserService;

        public UserController(IValidationUserService validationUserService, IMapper mapper, ILogger<UserModel> logger)
        {
            _validationUserService = validationUserService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(Name = "PostUser")]
        public IActionResult RegisterUser([FromBody] UserViewModel p)
        {
            var entity = _mapper.Map<UserModel>(p);
            var validation = new ValidationUserService();
            var resultValidation = validation.Validate(entity);

            if (!resultValidation.IsValid)
            {
                var resultado = new List<string>();
                foreach (var erro in resultValidation.Errors)
                    resultado.Add(erro.ErrorMessage);

                return BadRequest(resultado);
            }
            else
            {
                var passWordValidation = _validationUserService.ValidatePassword(entity.Password);
                if (!string.IsNullOrEmpty(passWordValidation))
                    return BadRequest(passWordValidation);

                var emailValidation = _validationUserService.ValidateEmail(entity.Email);

                if (!string.IsNullOrEmpty(emailValidation))
                    return BadRequest(emailValidation);
            }


            return Ok("User registered successfully");
        }
    }
}
