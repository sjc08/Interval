﻿namespace Asjc.Interval
{
    /// <summary>
    /// Represents a generic interval with start and end boundaries.
    /// </summary>
    /// <typeparam name="T">The type of the interval boundaries.</typeparam>
    public interface IInterval<T> where T : IComparable
    {
        /// <summary>
        /// Gets the start boundary of the interval.
        /// </summary>
        IntervalBoundary<T>? Start { get; }

        /// <summary>
        /// Gets the end boundary of the interval.
        /// </summary>
        IntervalBoundary<T>? End { get; }
    }
}
