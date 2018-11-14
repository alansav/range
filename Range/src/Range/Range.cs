using System.Linq;

namespace System.Numerics.Range
{
    public class Range<T> where T : IComparable<T>
    {
        public readonly T Floor;
        public readonly T Ceiling;

        public Range(T floor, T ceiling)
        {
            if (floor.CompareTo(ceiling) > 0)
                throw new ArgumentException("Value for ceiling must be equal to or greater than the value for floor.");

            Floor = floor;
            Ceiling = ceiling;
        }
        
        public bool InRange(T value)
        {
            return value.CompareTo(Floor) >= 0 && value.CompareTo(Ceiling) <= 0;
        }

        public virtual T FindClosestValue(T value)
        {
            if (value.CompareTo(this.Floor) < 0)
                return this.Floor;
            else if (value.CompareTo(this.Ceiling) > 0)
                return this.Ceiling;
            else
                return value;
        }
    }

    public class LinearDiscreteRange : Range<decimal>
    {
        public LinearDiscreteRange(decimal floor, decimal ceiling, decimal interval) : base(floor, ceiling)
        {
            this.Interval = interval;
        }
        public readonly decimal Interval;

        public override decimal FindClosestValue(decimal value)
        {
            if (value.CompareTo(this.Floor) < 0)
                return this.Floor;
            else if (value.CompareTo(this.Ceiling) > 0)
                return this.Ceiling;
            else
                return Math.Abs((value - this.Floor) / this.Interval) * this.Interval;
        }
    }

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
