using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sinqia.Bofa.Domain;
using Sinqia.Bofa.Service.Validation;
using Sinqia.Bofa.WebApi.Controllers;
using Sinqia.Bofa.WebApi.Models;

namespace Sinqia.Bofa.UnitTests
{
    public class UserUnitTest
    {
        [Fact]
        public void Create_User_ReturnsBadRequest()
        {
            // Arrange
            var p = new UserViewModel()
            {
                Name = null,
                Password = null,
                Email = null,
            };

            var controller = new UserController(Validation, Mapper, Logger);

            // Act
            var result = controller.RegisterUser(p) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.IsType<List<String>>(result.Value);
        }

        [Fact]
        public void Create_User_ReturnsBadRequestOnInvalidEmail()
        {
            // Arrange
            var p = new UserViewModel()
            {
                Name = "Leonardo Baldan Azevedo",
                Password = "LbfE@107*",
                Email = "leonardo.baldan.gmail.com",
            };

            var controller = new UserController(Validation, Mapper, Logger);

            // Act
            var result = controller.RegisterUser(p) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.IsType<String>(result.Value);
        }

        [Fact]
        public void Create_User_ReturnsBadRequestOnPasswordLength()
        {
            // Arrange
            var p = new UserViewModel()
            {
                Name = "Leonardo Baldan Azevedo",
                Password = "L@107*",
                Email = "leonardo.baldan@gmail.com",
            };

            var controller = new UserController(Validation, Mapper, Logger);

            // Act
            var result = controller.RegisterUser(p) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.IsType<String>(result.Value);
        }

        [Fact]
        public void Create_User_ReturnsBadRequestOnInvalidPassword()
        {
            // Arrange
            var p = new UserViewModel()
            {
                Name = "Leonardo Baldan Azevedo",
                Password = "LbfE@sinqia*",
                Email = "leonardo.baldan@gmail.com",
            };

            var controller = new UserController(Validation, Mapper, Logger);

            // Act
            var result = controller.RegisterUser(p) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.IsType<String>(result.Value);
        }

        [Fact]
        public void Create_User_ReturnsOk()
        {
            // Arrange
            var p = new UserViewModel()
            {
                Name = "Leonardo Baldan Azevedo",
                Password = "LbfE@3107*",
                Email = "leonardo.baldan@gmail.com",
            };

            var controller = new UserController(Validation, Mapper, Logger);

            // Act
            var result = controller.RegisterUser(p) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("User registered successfully", result.Value);
        }

        private ILogger<UserModel> Logger => LoggerFactory.Create(x => x.SetMinimumLevel(LogLevel.Debug))
            .CreateLogger<UserModel>();

        private ValidationUserService Validation => new ValidationUserService();

        private Mapper? Mapper => new Mapper(new MapperConfiguration(c => c.CreateMap<UserViewModel, UserModel>()));
    }
}
