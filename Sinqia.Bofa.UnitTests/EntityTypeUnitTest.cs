using Sinqia.Bofa.Factory.Entity;
using Xunit;

namespace Sinqia.Bofa.UnitTests
{
    public class EntityTypeUnitTest
    {
        [Fact]
        public void CreateTypeEntity_Returns_Company_WhenTypeIsCompany()
        {
            // Act
            var typeEntity = EntityTypeFactory.CreateTypeEntity("Company");

            // Assert
            Assert.IsType<Company>(typeEntity);
            Assert.Equal("Bofa", typeEntity.GetTypeEntity());
        }

        [Fact]
        public void CreateTypeEntity_Returns_Company_WhenTypeIsPerson()
        {
            // Act
            var typeEntity = EntityTypeFactory.CreateTypeEntity("Person");

            // Assert
            Assert.IsType<Person>(typeEntity);
            Assert.Equal("Leonardo", typeEntity.GetTypeEntity());
        }

        [Fact]
        public void CreateTypeEntity_Returns_Company_WhenTypeIsNotValid()
        {
            // Act and asserts
            Assert.Throws<ArgumentException>(() => EntityTypeFactory.CreateTypeEntity("NotValid"));
        }
    }
}