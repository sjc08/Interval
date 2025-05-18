namespace Asjc.Interval
{
    /// <summary>
    /// Represents a boundary point of an interval with a value and inclusivity flag.
    /// </summary>
    /// <typeparam name="T">The type of the boundary value.</typeparam>
    public record IntervalBoundary<T>(T Value, bool Inclusive) where T : IComparable
    {
        public IntervalBoundary(T value) : this(value, default) { }

        public static implicit operator IntervalBoundary<T>(T value) => new(value);
        public static explicit operator T(IntervalBoundary<T> value) => value.Value;
    }
}
