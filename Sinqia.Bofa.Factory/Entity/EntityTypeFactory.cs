using Sinqia.Bofa.Factory.Entity.Interface;

namespace Sinqia.Bofa.Factory.Entity
{
    public static class EntityTypeFactory
    {
        public static ITypeEntity CreateTypeEntity(string entityType)
        {
            return entityType switch
            {
                "Company" => new Company(),
                "Person" => new Person(),
                _ => throw new ArgumentException("Invalid product type", nameof(entityType))
            };
        }
    }
}
