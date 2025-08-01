namespace Asjc.Interval
{
    /// <inheritdoc cref="IInterval{T}"/>
    public class Interval<T> : IInterval<T>, IEquatable<Interval<T>> where T : IComparable
    {
        private IntervalBoundary<T>? start;
        private IntervalBoundary<T>? end;

        /// <inheritdoc/>
        public IntervalBoundary<T>? Start
        {
            get => start;
            init
            {
                ValidateBoundaries(value, End);
                start = value;
            }
        }

        /// <inheritdoc/>
        public IntervalBoundary<T>? End
        {
            get => end;
            init
            {
                ValidateBoundaries(Start, value);
                end = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T}"/> class with null boundaries.
        /// </summary>
        public Interval() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval{T}"/> class with the specified boundaries.
        /// </summary>
        /// <param name="start">The start boundary of the interval.</param>
        /// <param name="end">The end boundary of the interval.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="start"/> is greater than or equal to <paramref name="end"/>.</exception>
        public Interval(IntervalBoundary<T>? start, IntervalBoundary<T>? end)
        {
            ValidateBoundaries(start, end);
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Interval{T}"/> class with null boundaries.
        /// </summary>
        public static Interval<T> Create() => new();

        /// <summary>
        /// Creates a new instance of the <see cref="Interval{T}"/> class with the specified boundaries.
        /// </summary>
        /// <param name="start">The start boundary of the interval.</param>
        /// <param name="end">The end boundary of the interval.</param>
        public static Interval<T> Create(IntervalBoundary<T>? start = null, IntervalBoundary<T>? end = null)
            => new(start, end);

        /// <summary>
        /// Creates a new instance of the <see cref="Interval{T}"/> class with the specified boundaries.
        /// </summary>
        /// <param name="start">The start value of the interval.</param>
        /// <param name="end">The end value of the interval.</param>
        /// <param name="startInclusive">A <see langword="bool"/> indicating whether the start value is included in the interval.</param>
        /// <param name="endInclusive">A <see langword="bool"/> indicating whether the end value is included in the interval.</param>
        public static Interval<T> Create(T? start, T? end, bool startInclusive = true, bool endInclusive = false)
            => new(start is null ? null : new(start, startInclusive),
                   end is null ? null : new(end, endInclusive));

        private static void ValidateBoundaries(IntervalBoundary<T>? start, IntervalBoundary<T>? end)
        {
            if (start != null && end != null)
            {
                var cmp = start.Value.CompareTo(end.Value);
                if (cmp > 0)
                    throw new ArgumentException("Start value cannot be greater than End value.");
                if (cmp == 0 && !(start.Inclusive && end.Inclusive))
                    throw new ArgumentException("Start and End values cannot be equal unless both are inclusive.");
            }
        }

        /// <inheritdoc/>
        public bool Equals(Interval<T>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Start == other.Start && End == other.End;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Interval<T> other && Equals(other);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
#if NET8_0 || NETCOREAPP3_1 || NETSTANDARD2_1
            return HashCode.Combine(Start, End);
#else
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Start?.GetHashCode() ?? 0;
                hash = hash * 23 + End?.GetHashCode() ?? 0;
                return hash;
            }
#endif
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var l = Start != null ? Start.Value.ToString() : "−∞";
            var r = End != null ? End.Value.ToString() : "+∞";
            char lb = Start != null && Start.Inclusive ? '[' : '(';
            char rb = End != null && End.Inclusive ? ']' : ')';
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
