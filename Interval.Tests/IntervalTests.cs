namespace Asjc.Interval.Tests
{
    [TestClass]
    public class Interval
    {
        [TestMethod]
        public void Test()
        {
            Assert.ThrowsException<ArgumentException>(() => new Interval<int>(1, 0));
            Assert.ThrowsException<ArgumentException>(() => new Interval<int>(0, 0));
            Assert.ThrowsException<ArgumentException>(() => new Interval<int>(0, 1) { End = 0 });
            Assert.ThrowsException<ArgumentException>(() => Interval<int>.Create(0, 0));
            Assert.ThrowsException<ArgumentException>(() => Interval<int>.Create(1, 0));

            Assert.IsTrue(new Interval<int>(0, 1).Equals(new Interval<int>(0, 1)));
            Assert.IsTrue(new Interval<int>(0, 1).Equals((object)new Interval<int>(0, 1)));
            Assert.IsTrue(new Interval<int>(0, 1) == new Interval<int>(0, 1));
            Assert.IsTrue(new Interval<int>(null, null) == new Interval<int>(null, null));

            Assert.IsTrue(new Interval<int>(new(0, true), 1) == Interval<int>.Create(0, 1));
            Assert.IsTrue(new Interval<int>(0, 1) == Interval<int>.Create(0, 1, false));

            Assert.AreEqual(1, Interval<int>.Create(0, 1).CompareTo(-1));
            Assert.AreEqual(0, Interval<int>.Create(0, 1).CompareTo(0));
            Assert.AreEqual(-1, Interval<int>.Create(0, 1).CompareTo(1));
            Assert.AreEqual(0, Interval<int>.Create(0, null).CompareTo(1));

            Assert.IsTrue(Interval<int>.Create(0, 1).Contains(0));
            Assert.IsFalse(Interval<int>.Create(0, 1, startInclusive: false).Contains(0));
            Assert.IsFalse(Interval<int>.Create(0, 1).Contains(1));
            Assert.IsTrue(Interval<int>.Create(0, 1, endInclusive: true).Contains(1));
            Assert.IsTrue(Interval<int>.Create(0, null).Contains(int.MaxValue));

            Assert.AreEqual("[0, 0]", new Interval<int>(new(0, true), new(0, true)).ToString());
            Assert.AreEqual("[0, 1)", Interval<int>.Create(0, 1).ToString());
            Assert.AreEqual("(0, 1)", Interval<int>.Create(0, 1, startInclusive: false).ToString());
            Assert.AreEqual("[0, 1]", Interval<int>.Create(0, 1, endInclusive: true).ToString());
            Assert.AreEqual("(−∞, 0)", new Interval<int>(null, 0).ToString());
            Assert.AreEqual("(−∞, +∞)", new Interval<int>().ToString());
        }
    }
}