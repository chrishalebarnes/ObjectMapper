using ObjectMapper.Mapper;
using System;
using System.Collections;

namespace ObjectMapper.Test
{
    public static class TypeMaps
    {
        /// <summary>
        /// Two way map between TestObjectOne and TestObjectTwo
        /// </summary>
        public static IEnumerable TestObjectOneTestObjectTwoMap
        {
            get
            {
                //no named parameters is a bit more terse
                yield return new PropertyMap<TestObjectOne, TestObjectTwo, string>(
                    x => x.StringOne, (s, x) => x.StringOne = s,
                    x => x.StringTwo, (s, x) => x.StringTwo = s
                );

                //Named parameters can make the map a bit more clear
                yield return new PropertyMap<TestObjectOne, TestObjectTwo, int>(
                    t1Getter: x => x.IntOne, t1Setter: (i, x) => x.IntOne = i,
                    t2Getter: x => x.IntTwo, t2Setter: (i, x) => x.IntTwo = i
                );

                //Alternatively, use the Property constructors which is a bit more verbose
                yield return new PropertyMap<TestObjectOne, TestObjectTwo, DateTime>(
                    new Property<TestObjectOne, DateTime>(x => x.DateTimeOne, (d, x) => x.DateTimeOne = d),
                    new Property<TestObjectTwo, DateTime>(x => x.DateTimeTwo, (d, x) => x.DateTimeTwo = d)
                );

                //with a type conversion
                yield return new PropertyMap<TestObjectOne, TestObjectTwo, object>(
                    t1Getter: x => x.IntSixteen, t1Setter: (i, x) => x.IntSixteen = Convert.ToInt16(i),
                    t2Getter: x => x.IntThirtyTwo, t2Setter: (i, x) => x.IntThirtyTwo = Convert.ToInt32(i)
                );
            }
        }

        /// <summary>
        /// One way map from TestObjectOne to TestObjectTwo
        /// </summary>
        public static IEnumerable TestObjectOneTestObjectTwoSoloMap
        {
            get
            {
                yield return new PropertyMap<TestObjectOne, TestObjectTwo, string>(
                    x => x.StringOne, (s, x) => x.StringTwo = s
                );

                yield return new PropertyMap<TestObjectOne, TestObjectTwo, int>(
                    x => x.IntOne, (i, x) => x.IntTwo = i
                );

                yield return new PropertyMap<TestObjectOne, TestObjectTwo, DateTime>(
                    x => x.DateTimeOne, (d, x) => x.DateTimeTwo = d
                );

                yield return new PropertyMap<TestObjectOne, TestObjectTwo, object>(
                    x => x.IntSixteen, (i, x) => x.IntThirtyTwo = Convert.ToInt32(i)
                );
            }
        }
    }
}
