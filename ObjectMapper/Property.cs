using ObjectMapper.Interfaces;
using System;

namespace ObjectMapper.Mapper
{
    /// <summary>
    ///   Represents a single Property on an object with accessors
    /// </summary>
    /// <typeparam name="T">The parent object that has the property T</typeparam>
    /// <typeparam name="PropertyType">The type of the Property on T</typeparam>
    public struct Property<T, PropertyType> : IProperty<T, PropertyType>
    {
        /// <summary>
        /// Getter for a property on type T of type PropertyType
        /// </summary>
        public Func<T, PropertyType> Getter { get; private set; }

        /// <summary>
        /// Setter for a property on type T of type PropertyType
        /// </summary>
        public Action<PropertyType, T> Setter { get; private set; }

        /// <summary>
        ///   Instantiates this class with both a getter and setter.
        ///   Useful for two way maps
        /// </summary>
        public Property(Func<T, PropertyType> getter, Action<PropertyType, T> setter) : this()
        {
            this.Getter = getter;
            this.Setter = setter;
        }

        /// <summary>
        ///   Instantiates this class with only a getter.
        ///   Useful for one way maps
        /// </summary>
        public Property(Func<T, PropertyType> getter) : this()
        {
            this.Getter = getter;
        }

        /// <summary>
        ///   Instantiates this class with only a setter.
        ///   Useful for one way maps
        /// </summary>
        public Property(Action<PropertyType, T> setter) : this()
        {
            this.Setter = setter;
        }
    }
}
