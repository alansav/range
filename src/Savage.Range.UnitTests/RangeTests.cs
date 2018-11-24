using System;
using Xunit;

namespace Savage.Range
{
    public class RangeTest
    {
        [Fact]
        public void TestConstructor()
        {
            var range = new Range<int>(5, 100);

            Assert.Equal(5, range.Floor);
            Assert.Equal(100, range.Ceiling);
        }

        [Fact]
        public void TestFloorGreaterThanCeiling()
        {
            Assert.Throws<ArgumentException>(() => new Range<int>(100, 99));
        }

        [Fact]
        public void TestFindClosestValue()
        {
            const int TEST_MIN_VALUE = 5;
            const int TEST_MAX_VALUE = 100;
            var range = new Range<int>(TEST_MIN_VALUE, TEST_MAX_VALUE);

            const int TEST_INTERMEDIATE_CLOSEST_VALUE = 20;
            Assert.Equal(TEST_INTERMEDIATE_CLOSEST_VALUE, range.FindClosestValue(TEST_INTERMEDIATE_CLOSEST_VALUE));

            const int TEST_SUBMIN_CLOSEST_VALUE = 2;
            Assert.Equal(TEST_MIN_VALUE, range.FindClosestValue(TEST_SUBMIN_CLOSEST_VALUE));

            const int TEST_OVERMAX_CLOSEST_VALUE = 102;
            Assert.Equal(TEST_MAX_VALUE, range.FindClosestValue(TEST_OVERMAX_CLOSEST_VALUE));
        }

        [Theory]
        [InlineData(9, false)]
        [InlineData(10, true)]
        [InlineData(50, true)]
        [InlineData(100, true)]
        [InlineData(101, false)]
        public void TestInRangeForInt(int value, bool expected)
        {
            var range = new Range<int>(10, 100);

            Assert.Equal(expected, range.InRange(value));
        }

        
        [Fact]
        public void TestInRangeForDateTime()
        {
            var range = new Range<DateTime>(new DateTime(2000, 1, 1), new DateTime(2009, 12, 31));

            Assert.False(range.InRange(new DateTime(1999, 12, 31)));
            Assert.True(range.InRange(new DateTime(2000, 1, 1)));
            Assert.True(range.InRange(new DateTime(2005, 6, 15)));
            Assert.True(range.InRange(new DateTime(2009, 12, 31)));
            Assert.False(range.InRange(new DateTime(2010, 1, 1)));
        }
        
        [Theory]
        [InlineData("G", false)]
        [InlineData("H", true)]
        [InlineData("M", true)]
        [InlineData("R", true)]
        [InlineData("S", false)]
        public void TestInRangeForString(string value, bool expected)
        {
            var range = new Range<string>("H", "R");
            Assert.Equal(expected, range.InRange(value));
        }

        [Theory]
        [InlineData(-0.1, false)]
        [InlineData(0, true)]
        [InlineData(50, true)]
        [InlineData(100, true)]
        [InlineData(101.1, false)]
        public void TestInRangeForDecimal(decimal value, bool expected)
        {
            var range = new Range<Decimal>(0, 100);
            Assert.Equal(expected, range.InRange(value));
        }
    }
}
