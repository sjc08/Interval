namespace Asjc.Interval
{
    /// <summary>
    /// Provides extension methods for the <see cref="IInterval{T}"/> interface.
    /// </summary>
    public static class IntervalExtensions
    {
        /// <summary>
        /// Determines whether the <see cref="IInterval{T}"/> precedes, follows, or contains a specific value.
        /// </summary>
        /// <returns>A <see langword="bool"/> indicating the relationship between two objects.</returns>
        public static int CompareTo<T>(this IInterval<T> interval, T value) where T : struct, IComparable
        {
            if (interval.Start.HasValue)
            {
                int cmp = value.CompareTo(interval.Start.Value);
                if (cmp < 0 || (cmp == 0 && !interval.StartInclusive))
                    return 1;
            }
            if (interval.End.HasValue)
            {
                int cmp = value.CompareTo(interval.End.Value);
                if (cmp > 0 || (cmp == 0 && !interval.EndInclusive))
                    return -1;
            }
            return 0;
        }

        /// <summary>
        /// Determines whether the <see cref="IInterval{T}"/> contains a specific value.
        /// </summary>
        /// <returns><see langword="true"/> if <paramref name="value"/> is in the <paramref name="interval"/>; otherwise, <see langword="false"/>.</returns>
        public static bool Contains<T>(this IInterval<T> interval, T value) where T : struct, IComparable 
            => interval.CompareTo(value) == 0;
    }
}
