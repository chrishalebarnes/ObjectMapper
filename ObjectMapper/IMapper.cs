using System.Collections;

namespace ObjectMapper.Interfaces
{
    public interface IMapper<T1, T2> where T1 : new() where T2 : new()
    {
        IEnumerable TypeMap { get; set; }
        T1 Map(T2 t2);
        T2 Map(T1 t1);
        IMapper<T1, T2> Use(IEnumerable typeMap);
    }
}