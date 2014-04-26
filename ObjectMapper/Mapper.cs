using ObjectMapper.Interfaces;
using System.Collections;

namespace ObjectMapper.Mapper
{
    /// <summary>
    ///   A generic object that takes two types and maps two ways between them.
    ///   Requires the use of a TypeMap which is intended to be an IEnummerable of anonymous Funcs that perfrom the mapping.
    /// </summary>
    /// <typeparam name="T1">Type of first object to map.</typeparam>
    /// <typeparam name="T2">Type of second object to map.</typeparam>
    /// <example>
    ///     See MapperTest.cs in the ObjectMapper.Test project for an example.
    /// </example>
    public class Mapper<T1, T2> : IMapper<T1, T2> where T1 : new() where T2 : new()
    {
        /// <summary>
        /// Anonymous IEnumerable of Funcs that perform a mapping from T1 to T2 and from T2 to T1.
        /// The Use method is fluent and will also set this property.
        /// </summary>
        public IEnumerable TypeMap { get; set; }

        /// <summary>
        ///   Fluent method that sets TypeMap.
        /// </summary>
        public IMapper<T1, T2> Use(IEnumerable typeMap)
        {
            this.TypeMap = typeMap;
            return this;
        }

        /// <summary>
        ///   Map from T1 to T2.
        /// </summary>
        /// <param name="t1">Object to map from</param>
        /// <returns>New instance of T2</returns>
        public T2 Map(T1 t1)
        {
            T2 t2 = new T2();
            foreach(dynamic map in this.TypeMap)
            {
                map.TypeTwoAccessor.Setter(map.TypeOneAccessor.Getter(t1), t2);
            }
            return t2;
        }

        /// <summary>
        ///   Map From T2 to T1.
        /// </summary>
        /// <param name="t2">Object to map from</param>
        /// <returns>New instance of T1</returns>
        public T1 Map(T2 t2)
        {
            T1 t1 = new T1();
            foreach (dynamic map in this.TypeMap)
            {
                map.TypeOneAccessor.Setter(map.TypeTwoAccessor.Getter(t2), t1);
            }
            return t1;
        }
    }
}
