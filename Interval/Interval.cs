namespace Asjc.Interval
{
    /// <inheritdoc cref="IInterval{T}"/>
    public class Interval<T> : IInterval<T>, IEquatable<Interval<T>> where T : struct, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T}"/> class with null boundaries.
        /// </summary>
        public Interval() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T}"/> class with the specified boundaries.
        /// </summary>
        /// <param name="start">The start boundary of the interval.</param>
        /// <param name="end">The end boundary of the interval.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="start"/> is greater than <paramref name="end"/>.</exception>
        public Interval(T? start, T? end)
        {
            if (start.HasValue && end.HasValue && start.Value.CompareTo(end.Value) > 0)
                throw new ArgumentException($"{nameof(start)} must be less than or equal to {nameof(end)}");
            Start = start;
            End = end;
        }

        /// <inheritdoc/>
        public T? Start { get; }

        /// <inheritdoc/>
        public T? End { get; }

        /// <inheritdoc/>
        public bool Equals(Interval<T>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(Start, other.Start) &&
                   Nullable.Equals(End, other.End);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Interval<T> other && Equals(other);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => (Start, End).GetHashCode();

        public static bool operator ==(Interval<T> left, Interval<T> right) => Equals(left, right);

        public static bool operator !=(Interval<T> left, Interval<T> right) => !Equals(left, right);
    }
}
