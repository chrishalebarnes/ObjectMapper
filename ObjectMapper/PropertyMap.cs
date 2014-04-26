using ObjectMapper.Interfaces;
using System;

namespace ObjectMapper.Mapper
{
    /// <summary>
    ///   Represents a two way map between two properties on two objects.
    /// </summary>
    /// <typeparam name="TypeOne">First object.</typeparam>
    /// <typeparam name="TypeTwo">Second object.</typeparam>
    /// <typeparam name="PropertyType">Type of the property on both TypeOne and TypeTwo.</typeparam>
    public struct PropertyMap<TypeOne, TypeTwo, PropertyType> : IPropertyMap<TypeOne, TypeTwo, PropertyType>
    {
        /// <summary>
        /// Get and Set properties for a property on TypeOne
        /// </summary>
        public IProperty<TypeOne, PropertyType> TypeOneAccessor { get; private set; }

        /// <summary>
        /// Get and Set properties for a property on TypeTwo.
        /// </summary>
        public IProperty<TypeTwo, PropertyType> TypeTwoAccessor { get; private set; }

        /// <summary>
        ///   Instantiates this class with both accessors to both TypeOne and TypeTwo.
        /// </summary>
        /// <param name="typeOneAccessor">Both get and set methods for a property on TypeOne.</param>
        /// <param name="typeTwoAccessor">Both get and set methods for a property on TypeTwo.</param>
        public PropertyMap(IProperty<TypeOne, PropertyType> typeOneAccessor, IProperty<TypeTwo, PropertyType> typeTwoAccessor) : this()
        {
            this.TypeOneAccessor = typeOneAccessor;
            this.TypeTwoAccessor = typeTwoAccessor;
        }

        /// <summary>
        ///   Instantiates this class with getters and setters for a property on TypeOne and TypeTwo.
        ///   Points to the other PropertyMap constructor.
        /// </summary>
        /// <param name="t1Getter">Getter for a property on TypeOne.</param>
        /// <param name="t1Setter">Setter for a property on TypeOne.</param>
        /// <param name="t2Getter">Getter for a property on TypeTwo.</param>
        /// <param name="t2Setter">Setter for a property on TypeTwo.</param>
        public PropertyMap(Func<TypeOne, PropertyType> t1Getter, Action<PropertyType, TypeOne> t1Setter, Func<TypeTwo, PropertyType> t2Getter, Action<PropertyType, TypeTwo> t2Setter)
            : this(new Property<TypeOne, PropertyType>(t1Getter, t1Setter), new Property<TypeTwo, PropertyType>(t2Getter, t2Setter))
        { }

        /// <summary>
        ///   Instantiates this class with a getter for T1 and a setter for T2.
        ///   Acts as a one way map from T1 to T2
        /// </summary>
        /// <param name="t1Getter"></param>
        /// <param name="t2Setter"></param>
        public PropertyMap(Func<TypeOne, PropertyType> t1Getter, Action<PropertyType, TypeTwo> t2Setter) : this()
        {
            this.TypeOneAccessor = new Property<TypeOne, PropertyType>(t1Getter);
            this.TypeTwoAccessor = new Property<TypeTwo, PropertyType>(t2Setter);
        }
    }
}