using System;

namespace Savage.Range
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
            if (value.CompareTo(Floor) < 0)
            {
                return Floor;
            }
            else if (value.CompareTo(Ceiling) > 0)
            {
                return Ceiling;
            }
            else
            {
                return value;
            }
        }
    }
}