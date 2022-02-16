using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResearchTree.Models;
using System.Collections.Generic;

namespace ResearchTree.Tests
{
    [TestClass]
    [TestCategory("L0")]
    public class ResearchControllerTests
    {
        [TestMethod]
        public void ResearchItemsAreActiveTest()
        {
            //Arrange
            ResearchController controller = new();
            controller.BuildDemoList();

            //Act
            List<ResearchItem> results = controller.GetAvailableResearchItems();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void ResearchItemsAreCompletedTest()
        {
            //Arrange
            ResearchController controller = new();
            controller.BuildDemoList();

            //Act
            List<ResearchItem> results = controller.GetCompletedResearchItems();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void ResearchItemsPositionTest()
        {
            //Arrange
            ResearchController controller = new();
            controller.BuildDemoList();

            //Act
            

            //Assert
            Assert.IsNotNull(controller.ResearchItems);
            Assert.IsTrue(controller.ResearchItems.Count > 0);

            //First Level
            Assert.IsNotNull(controller.ResearchItems[0]);
            Assert.AreEqual(1, controller.ResearchItems[0].Level);

            //Second Level
            Assert.IsNotNull(controller.ResearchItems[1]);
            Assert.AreEqual(2, controller.ResearchItems[1].Level);
            Assert.IsNotNull(controller.ResearchItems[2]);
            Assert.AreEqual(2, controller.ResearchItems[2].Level);

            //Third Level
            Assert.IsNotNull(controller.ResearchItems[3]);
            Assert.AreEqual(3, controller.ResearchItems[3].Level);

            //Fourth Level
            Assert.IsNotNull(controller.ResearchItems[4]);
            Assert.AreEqual(4, controller.ResearchItems[4].Level);
            Assert.IsNotNull(controller.ResearchItems[5]);
            Assert.AreEqual(4, controller.ResearchItems[5].Level);

            //Fifth Level
            Assert.IsNotNull(controller.ResearchItems[6]);
            Assert.AreEqual(5, controller.ResearchItems[6].Level);


        }

    }
}