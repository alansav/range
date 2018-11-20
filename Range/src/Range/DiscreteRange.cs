using System;
using System.Linq;
using System.Numerics;

namespace Range
{
    public class DiscreteRange<T> : Range<T> where T : IComparable<T>
    {
        public DiscreteRange(IOrderedEnumerable<T> discreteValue) : base(discreteValue.First(), discreteValue.Last())
        {
            this.DiscreteValues = discreteValue;
        }
        public readonly IOrderedEnumerable<T> DiscreteValues;

        public override T FindClosestValue(T value)
        {
            return this.DiscreteValues.OrderBy(discreteValue => (uint)(value.CompareTo(discreteValue))).First();
        }
    }
}
