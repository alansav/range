using System;

namespace Savage
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
    }
}
