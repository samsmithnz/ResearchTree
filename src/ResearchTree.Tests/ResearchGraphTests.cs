using ResearchTree.Models;
using ResearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResearchTree.Tests
{
    [TestClass]
    [TestCategory("L0")]
    public class ResearchGraphTests
    {
        [TestMethod]
        public void ResearchIronWorkingGraphTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateIronWorking();

            //Act            


            //Assert
            TestIronWorking(item);
        }

        private static void TestIronWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Iron Working", item.Name);
            Assert.IsNotNull(item.PreReqs);
            Assert.AreEqual(ResearchPool.CreateBronzeWorking().Name, item.PreReqs[0]);
            Assert.AreEqual(20, item.WorkToComplete);
            Assert.AreEqual(3, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

    }
}