using System;

namespace Savage.Range
{
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
}
