namespace Asjc.Interval
{
    /// <summary>
    /// Provides extension methods for the <see cref="IInterval{T}"/> interface.
    /// </summary>
    public static class IntervalExtensions
    {
        /// <summary>
        /// Determines whether the <see cref="IInterval{T}"/> contains a specific value.
        /// </summary>
        /// <returns><see langword="true"/> if <paramref name="value"/> is in the <paramref name="interval"/>; otherwise, <see langword="false"/>.</returns>
        public static bool Contains<T>(this IInterval<T> interval, T value) where T : struct, IComparable
        {
            if (interval.Start.HasValue)
            {
                if (interval.StartInclusive)
                {
                    if (value.CompareTo(interval.Start.Value) < 0)
                        return false;
                }
                else
                {
                    if (value.CompareTo(interval.Start.Value) <= 0)
                        return false;
                }
            }
            if (interval.End.HasValue)
            {
                if (interval.EndInclusive)
                {
                    if (value.CompareTo(interval.End.Value) > 0)
                        return false;
                }
                else
                {
                    if (value.CompareTo(interval.End.Value) >= 0)
                        return false;
                }
            }
            return true;
        }
    }
}
