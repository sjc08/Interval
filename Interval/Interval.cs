#pragma warning disable CS1591
namespace Asjc.Interval
{
    public class Interval<T> : IEquatable<Interval<T>> where T : struct, IComparable
    {
        public Interval() { }

        public Interval(T? start, T? end)
        {
            if (start.HasValue && end.HasValue && start.Value.CompareTo(end.Value) > 0)
                throw new ArgumentException($"{nameof(start)} must be less than or equal to {nameof(end)}");
            Start = start;
            End = end;
        }

        public T? Start { get; }

        public T? End { get; }

        public bool Equals(Interval<T>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(Start, other.Start) &&
                   Nullable.Equals(End, other.End);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Interval<T> other && Equals(other);
        }

        public override int GetHashCode() => (Start, End).GetHashCode();

        public static bool operator ==(Interval<T> left, Interval<T> right) => Equals(left, right);

        public static bool operator !=(Interval<T> left, Interval<T> right) => !Equals(left, right);
    }
}
