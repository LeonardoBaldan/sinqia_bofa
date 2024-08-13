using Sinqia.Bofa.Service.Singleton;

namespace Sinqia.Bofa.UnitTests
{
    public class SingletonUnitTests
    {
        [Fact]
        public void SingletonService_Instance_ReturnsSameInstances()
        {
            // Act
            var primaryInstance = SingletonService.Instance;
            var secondInstance = SingletonService.Instance;

            // Assert
            Assert.Same(primaryInstance, secondInstance);
        }

        [Fact]
        public void SingletonManager_CreateInstance_MethodOk()
        {
            // Arrange
            var instance = SingletonService.Instance;

            // Act and Assert
            // Verify that the method works without exceptions
            instance.CreateInstanceOfSingleton();
        }
    }
}
