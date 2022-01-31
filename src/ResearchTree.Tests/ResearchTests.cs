using ResearchTree.Models;
using ResearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResearchTree.Tests
{
    [TestClass]
    [TestCategory("L0")]
    public class ResearchTests
    {
        [TestMethod]
        public void ResearchBronzeWorkingTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateBronzeWorking();

            //Act            

            //Assert
            TestBronzeWorking(item);
        }

        [TestMethod]
        public void ResearchIronWorkingTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateIronWorking();

            //Act            

            //Assert
            TestIronWorking(item);
        }

        [TestMethod]
        public void ResearchSteelWorkingTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateSteelWorking();

            //Act            

            //Assert
            TestSteelWorking(item);
        }

        private static void TestBronzeWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Bronze Working", item.Name);
            Assert.IsNull(item.ResearchPrereq);
            Assert.AreEqual(5, item.WorkToComplete);
            Assert.AreEqual(5, item.WorkCompleted);
            Assert.AreEqual(true, item.IsComplete);
        }

        private static void TestIronWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Iron Working", item.Name);
            Assert.IsNotNull(item.ResearchPrereq);
            Assert.AreEqual(ResearchPool.CreateBronzeWorking().Name, item.ResearchPrereq.Name);
            Assert.AreEqual(20, item.WorkToComplete);
            Assert.AreEqual(3, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

        private static void TestSteelWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Steel Working", item.Name);
            Assert.IsNotNull(item.ResearchPrereq);
            Assert.AreEqual(ResearchPool.CreateIronWorking().Name, item.ResearchPrereq.Name);
            Assert.AreEqual(50, item.WorkToComplete);
            Assert.AreEqual(0, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

    }
}