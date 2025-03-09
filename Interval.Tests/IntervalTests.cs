namespace Asjc.Interval.Tests
{
    [TestClass]
    public class Interval
    {
        [TestMethod]
        public void Test()
        {
            Assert.ThrowsException<ArgumentException>(() => new Interval<int>(1, 0));
            Assert.ThrowsException<ArgumentException>(() => new Interval<int>(0, 0, startInclusive: false));

            Assert.IsTrue(new Interval<int>(0, 1).Equals(new Interval<int>(0, 1)));
            Assert.IsTrue(new Interval<int>(0, 1).Equals((object)new Interval<int>(0, 1)));
            Assert.IsTrue(new Interval<int>(0, 1) == new Interval<int>(0, 1));
            Assert.IsFalse(new Interval<int>(null, null, false, false) == new Interval<int>(null, null, true, true)); // debatable

            Assert.AreEqual(0, new Interval<int>(0, 1).CompareTo(0));
            Assert.AreEqual(-1, new Interval<int>(0, 1).CompareTo(1));
            Assert.AreEqual(0, new Interval<int>(0, null).CompareTo(1));

            Assert.IsTrue(new Interval<int>(0, 1).Contains(0));
            Assert.IsFalse(new Interval<int>(0, 1, startInclusive: false).Contains(0));
            Assert.IsFalse(new Interval<int>(0, 1).Contains(1));
            Assert.IsTrue(new Interval<int>(0, 1, endInclusive: true).Contains(1));
            Assert.IsTrue(new Interval<int>(0, null).Contains(int.MaxValue));

            Assert.AreEqual("[0, 1)", new Interval<int>(0, 1).ToString());
            Assert.AreEqual("(0, 1)", new Interval<int>(0, 1, startInclusive: false).ToString());
            Assert.AreEqual("[0, 1]", new Interval<int>(0, 1, endInclusive: true).ToString());
            Assert.AreEqual("(−∞, +∞)", new Interval<int>().ToString());
            Assert.AreEqual("[−∞, +∞]", new Interval<int>(null, null, true, true).ToString()); // debatable
        }
    }
}