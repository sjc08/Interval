namespace Asjc.Interval
{
    public static class IntervalExtensions
    {
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
