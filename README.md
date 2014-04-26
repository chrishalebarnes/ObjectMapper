Object Mapper
=============

A zero-reflection, type-safe object to object mapper.

## Getting Started
Map an object to another like this:
	```C#
    var mapper = new Mapper<TestObjectOne, TestObjectTwo>();
	TestObjectTwo two = GetTestObjectTwo();
    TestObjectOne mappedOne = mapper.Use(TypeMaps.TestObjectOneTestObjectTwoMap).Map(two);
	```
where TypeMaps.TestObjectOneTestObjectTwoMap is an IEnumerable of Funcs that are getters and setters. Like this:
	```C#
	public static IEnumerable TestObjectOneTestObjectTwoMap
    {
		get
        {
			//Needs one of these per mappable property.
            yield return new PropertyMap<TestObjectOne, TestObjectTwo, string>(
	            x => x.StringOne, (s, x) => x.StringOne = s,
                x => x.StringTwo, (s, x) => x.StringTwo = s
			);
		}
	}
	```
There are a few more examples, including a one way map, in the unit test. See [MapperTest.cs](https://github.com/chrishalebarnes/ObjectMapper/blob/master/ObjectMapper.Test/MapperTest.cs).

##License and Copyright

See [LICENSE](https://github.com/chrishalebarnes/ObjectMapper/blob/master/LICENSE)
