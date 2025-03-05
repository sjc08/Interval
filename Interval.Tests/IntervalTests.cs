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
        }
    }
}