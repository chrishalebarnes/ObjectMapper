
namespace ObjectMapper.Interfaces
{
    public interface IPropertyMap<TypeOne, TypeTwo, PropertyType>
    {
        IProperty<TypeOne, PropertyType> TypeOneAccessor { get; }
        IProperty<TypeTwo, PropertyType> TypeTwoAccessor { get; }
    }
}
