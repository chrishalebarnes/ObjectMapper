using System;

namespace ObjectMapper.Interfaces
{
    public interface IProperty<T, PropertyType>
    {
        Func<T, PropertyType> Getter { get; }
        Action<PropertyType, T> Setter { get; }
    }
}
