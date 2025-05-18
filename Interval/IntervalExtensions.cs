namespace Asjc.Interval
{
    /// <summary>
    /// Provides extension methods for the <see cref="IInterval{T}"/> interface.
    /// </summary>
    public static class IntervalExtensions
    {
        /// <summary>
        /// Compares the <see cref="IInterval{T}"/> with a specific value.
        /// </summary>
        /// <returns>An <see langword="int"/> indicating whether <paramref name="interval"/> precedes, follows, or contains <paramref name="value"/>.</returns>
        public static int CompareTo<T>(this IInterval<T> interval, T value) where T : IComparable
        {
            if (interval.Start != null)
            {
                int cmp = value.CompareTo(interval.Start.Value);
                if (cmp < 0 || (cmp == 0 && !interval.Start.Inclusive))
                    return 1;
            }
            if (interval.End != null)
            {
                int cmp = value.CompareTo(interval.End.Value);
                if (cmp > 0 || (cmp == 0 && !interval.End.Inclusive))
                    return -1;
            }
            return 0;
        }

        /// <summary>
        /// Determines whether the <see cref="IInterval{T}"/> contains a specific value.
        /// </summary>
        /// <returns><see langword="true"/> if <paramref name="value"/> is in the <paramref name="interval"/>; otherwise, <see langword="false"/>.</returns>
        public static bool Contains<T>(this IInterval<T> interval, T value) where T : IComparable
            => interval.CompareTo(value) == 0;
    }
}
