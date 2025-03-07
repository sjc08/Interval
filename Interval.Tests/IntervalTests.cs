namespace Asjc.Interval.Tests
{
    [TestClass]
    public class Interval
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(new Interval<int>(0, 1).Equals(new Interval<int>(0, 1)));
            Assert.IsTrue(new Interval<int>(0, 1).Equals((object)new Interval<int>(0, 1)));
            Assert.IsTrue(new Interval<int>(0, 1) == new Interval<int>(0, 1));

            Assert.IsTrue(new Interval<int>(0, 1).Contains(0));
            Assert.IsFalse(new Interval<int>(0, 1, startInclusive: false).Contains(0));
            Assert.IsFalse(new Interval<int>(0, 1).Contains(1));
            Assert.IsTrue(new Interval<int>(0, 1, endInclusive: true).Contains(1));

            Assert.AreEqual("[0, 1)", new Interval<int>(0, 1).ToString());
            Assert.AreEqual("(0, 1)", new Interval<int>(0, 1, startInclusive: false).ToString());
            Assert.AreEqual("[0, 1]", new Interval<int>(0, 1, endInclusive: true).ToString());
            Assert.AreEqual("(−∞, +∞)", new Interval<int>().ToString());
        }
    }
}