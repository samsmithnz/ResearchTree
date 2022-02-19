using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResearchTree.Models;

namespace ResearchTree.Tests
{
    [TestClass]
    [TestCategory("L0")]
    public class ResearchGraphTests
    {
        [TestMethod]
        public void ResearchCGraphTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateC();

            //Act            


            //Assert
            TestIronWorking(item);
        }

        private static void TestIronWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("C", item.Name);
            Assert.IsNotNull(item.PreReqs);
            Assert.AreEqual(ResearchPool.CreateA().Name, item.PreReqs[0]);
            Assert.AreEqual(20, item.WorkToComplete);
            Assert.AreEqual(3, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

    }
}