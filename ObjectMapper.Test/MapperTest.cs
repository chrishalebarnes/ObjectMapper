using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectMapper.Interfaces;
using ObjectMapper.Mapper;
using System;

namespace ObjectMapper.Test
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void MapTwoWayAndAssertEquality()
        {
            //var mapper = ...; would also work :)
            IMapper<TestObjectOne, TestObjectTwo> mapper = new Mapper<TestObjectOne, TestObjectTwo>();

            //Map an instance of TestObjectTwo to TestObjectOne using the type map
            TestObjectTwo two = GetTestObjectTwo();
            TestObjectOne mappedOne = mapper.Use(TypeMaps.TestObjectOneTestObjectTwoMap).Map(two);
            
            //Assert all three properties on the new mappedOne equal the properties on two
            Assert.AreEqual(mappedOne.StringOne, two.StringTwo);
            Assert.AreEqual(mappedOne.IntOne, two.IntTwo);
            Assert.AreEqual(mappedOne.DateTimeOne, two.DateTimeTwo);
            int i32 = (int)mappedOne.IntSixteen;
            Assert.AreEqual(i32, two.IntThirtyTwo);

            //Map an instance of TestObjectOne to TestObjectTwo using the type map
            TestObjectOne one = GetTestObjectOne();
            TestObjectTwo mappedTwo = mapper.Use(TypeMaps.TestObjectOneTestObjectTwoMap).Map(one);
            
            //Assert all three properties on the new mappedTwo equal the properties on one
            Assert.AreEqual(mappedTwo.StringTwo, one.StringOne);
            Assert.AreEqual(mappedTwo.IntTwo, one.IntOne);
            Assert.AreEqual(mappedTwo.DateTimeTwo, one.DateTimeOne);
            Int16 i16 = (Int16)mappedTwo.IntThirtyTwo;
            Assert.AreEqual(i16, one.IntSixteen);
        }

        [TestMethod]
        public void MapOneWayAndAssertEquality()
        {
            var mapper = new Mapper<TestObjectOne, TestObjectTwo>();

            TestObjectOne one = this.GetTestObjectOne();

            TestObjectTwo mappedTwo = mapper.Use(TypeMaps.TestObjectOneTestObjectTwoSoloMap).Map(one);
            Assert.AreEqual(mappedTwo.StringTwo, one.StringOne);
            Assert.AreEqual(mappedTwo.IntTwo, one.IntOne);
            Assert.AreEqual(mappedTwo.DateTimeTwo, one.DateTimeOne);
            Int16 i16 = (Int16)mappedTwo.IntThirtyTwo;
            Assert.AreEqual(i16, one.IntSixteen);
        }

        protected TestObjectOne GetTestObjectOne()
        {
            return new TestObjectOne()
            {
                StringOne = "test one",
                IntOne = 4,
                DateTimeOne = new DateTime(2014, 3, 5),
                IntSixteen = 7
            };
        }

        protected TestObjectTwo GetTestObjectTwo()
        {
            return new TestObjectTwo()
            {
                StringTwo = "test two",
                IntTwo = 8,
                DateTimeTwo = new DateTime(2014, 8, 10),
                IntThirtyTwo = 8
            };
        }
    }
}
