using System;
using System.Linq;

namespace Savage.Range
{
    public class DiscreteRange<T> : Range<T> where T : IComparable<T>
    {
        public DiscreteRange(IOrderedEnumerable<T> discreteValue) : base(discreteValue.First(), discreteValue.Last())
        {
            DiscreteValues = discreteValue;
        }
        public readonly IOrderedEnumerable<T> DiscreteValues;

        public override T FindClosestValue(T value)
        {
            return DiscreteValues.OrderBy(discreteValue => (uint)(value.CompareTo(discreteValue))).First();
        }
    }
}
