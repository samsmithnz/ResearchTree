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
        public void ResearchBasicMiningTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateBasicMining();

            //Act            

            //Assert
            TestBasicMining(item);
        }
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

        private static void TestBasicMining(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Basic Mining", item.Name);
            Assert.AreEqual(0, item.PreReqs.Count);
            Assert.AreEqual(1, item.WorkToComplete);
            Assert.AreEqual(1, item.WorkCompleted);
            Assert.AreEqual(true, item.IsComplete);
        }

        private static void TestBronzeWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Bronze Working", item.Name);
            Assert.AreEqual(1, item.PreReqs.Count);
            Assert.AreEqual(5, item.WorkToComplete);
            Assert.AreEqual(5, item.WorkCompleted);
            Assert.AreEqual(true, item.IsComplete);
        }

        private static void TestIronWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Iron Working", item.Name);
            Assert.AreEqual(1, item.PreReqs.Count);
            Assert.AreEqual(ResearchPool.CreateBronzeWorking().Name, item.PreReqs[0].Name);
            Assert.AreEqual(20, item.WorkToComplete);
            Assert.AreEqual(3, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

        private static void TestSteelWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Steel Working", item.Name);
            Assert.AreEqual(1, item.PreReqs.Count);
            Assert.AreEqual(ResearchPool.CreateIronWorking().Name, item.PreReqs[0].Name);
            Assert.AreEqual(50, item.WorkToComplete);
            Assert.AreEqual(0, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

        private static void TestTitaniumWorking(ResearchItem item)
        {
            Assert.IsNotNull(item);
            Assert.AreEqual("Titanium Working", item.Name);
            Assert.AreEqual(2, item.PreReqs.Count);
            Assert.AreEqual(ResearchPool.CreateAdvancedMining().Name, item.PreReqs[0].Name);
            Assert.AreEqual(ResearchPool.CreateSteelWorking().Name, item.PreReqs[1].Name);
            Assert.AreEqual(100, item.WorkToComplete);
            Assert.AreEqual(0, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

    }
}