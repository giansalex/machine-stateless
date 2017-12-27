using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkFlowSample.Tests
{
    [TestClass]
    public class MainStateTests
    {
        [TestMethod]
        public void RunTest()
        {
            var machine = new MainState();

            Assert.AreEqual(State.Open, machine.State);

            machine.Fire(Trigger.Assign);
            Assert.AreEqual(State.Assigned, machine.State);

            machine.Fire(Trigger.Defer);
            Assert.AreEqual(State.Deferred, machine.State);
        }
    }
}