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
        /// <param name="startInclusive">A value indicating whether the start boundary is included in the interval.</param>
        /// <param name="endInclusive">A value indicating whether the end boundary is included in the interval.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="start"/> is greater than <paramref name="end"/>.</exception>
        public Interval(T? start, T? end, bool startInclusive = true, bool endInclusive = false)
        {
            if (start.HasValue && end.HasValue)
            {
                var cmp = start.Value.CompareTo(end.Value);
                if (cmp > 0)
                    throw new ArgumentException($"{nameof(start)} must be less than or equal to {nameof(end)}");
                if (cmp == 0 && !(startInclusive && endInclusive))
                    throw new ArgumentException($"When {nameof(start)} is equal to {nameof(end)}, both {nameof(startInclusive)} and {nameof(endInclusive)} must be true");
            }

            Start = start;
            End = end;
            StartInclusive = startInclusive;
            EndInclusive = endInclusive;
        }

        /// <inheritdoc/>
        public T? Start { get; }

        /// <inheritdoc/>
        public T? End { get; }

        /// <inheritdoc/>
        public bool StartInclusive { get; }

        /// <inheritdoc/>
        public bool EndInclusive { get; }

        /// <inheritdoc/>
        public bool Equals(Interval<T>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(Start, other.Start) &&
                   Nullable.Equals(End, other.End) &&
                   StartInclusive == other.StartInclusive &&
                   EndInclusive == other.EndInclusive;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Interval<T> other && Equals(other);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => (Start, End, StartInclusive, EndInclusive).GetHashCode();

        /// <inheritdoc/>
        public override string ToString()
        {
            string l = Start?.ToString() ?? "−∞";
            string r = End?.ToString() ?? "+∞";
            char lb = StartInclusive ? '[' : '(';
            char rb = EndInclusive ? ']' : ')';
            return $"{lb}{l}, {r}{rb}";
        }

        /// <summary>
        /// Compares two <see cref="Interval{T}"/> objects.
        /// </summary>
        public static bool operator ==(Interval<T> left, Interval<T> right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="Interval{T}"/> objects.
        /// </summary>
        public static bool operator !=(Interval<T> left, Interval<T> right) => !Equals(left, right);
    }
}
