using System;

namespace Savage.Range
{
    public class LinearDiscreteRange : Range<decimal>
    {
        public LinearDiscreteRange(decimal floor, decimal ceiling, decimal interval) : base(floor, ceiling)
        {
            Interval = interval;
        }

        public readonly decimal Interval;

        public override decimal FindClosestValue(decimal value)
        {
            if (value.CompareTo(Floor) < 0)
                return Floor;
            else if (value.CompareTo(Ceiling) > 0)
                return Ceiling;
            else
                return Math.Abs((value - Floor) / Interval) * Interval;
        }
    }
}
