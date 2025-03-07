namespace Asjc.Interval
{
    /// <summary>
    /// Represents a generic interval with start and end boundaries.
    /// </summary>
    /// <typeparam name="T">The type of the interval boundaries.</typeparam>
    public interface IInterval<T> where T : struct, IComparable
    {
        /// <summary>
        /// Gets the start boundary of the interval.
        /// </summary>
        T? Start { get; }

        /// <summary>
        /// Gets the end boundary of the interval.
        /// </summary>
        T? End { get; }

        /// <summary>
        /// Gets a value indicating whether the start boundary is included in the interval.
        /// </summary>
        bool StartInclusive { get; }

        /// <summary>
        /// Gets a value indicating whether the end boundary is included in the interval.
        /// </summary>
        bool EndInclusive { get; }
    }
}
