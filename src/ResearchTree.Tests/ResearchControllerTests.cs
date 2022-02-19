using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResearchTree.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ResearchTree.Tests
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L0")]
    public class ResearchControllerTests
    {
        [TestMethod]
        public void ResearchItemsAreActiveTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchController controller = new(items);

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
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchController controller = new(items);

            //Act
            List<ResearchItem> results = controller.GetCompletedResearchItems();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void ResearchItemsPositionTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchController controller = new(items);

            //Act
            foreach (ResearchItem item in controller.ResearchItems)
            {
                item.Width = 100;
            }

            //Assert
            Assert.IsNotNull(controller.ResearchItems);
            Assert.IsTrue(controller.ResearchItems.Count > 0);

            //First Level
            Assert.IsNotNull(controller.ResearchItems[0]);
            Assert.AreEqual(1, controller.ResearchItems[0].Level);
            Assert.AreEqual(new Vector3(50, 50, 0), controller.ResearchItems[0].Location);

            //Second Level
            Assert.IsNotNull(controller.ResearchItems[1]);
            Assert.AreEqual(2, controller.ResearchItems[1].Level);
            Assert.AreEqual(new Vector3(200, 50, 0), controller.ResearchItems[1].Location);
            Assert.IsNotNull(controller.ResearchItems[2]);
            Assert.AreEqual(2, controller.ResearchItems[2].Level);
            Assert.AreEqual(new Vector3(200, 200, 0), controller.ResearchItems[2].Location);

            //Third Level
            Assert.IsNotNull(controller.ResearchItems[3]);
            Assert.AreEqual(2, controller.ResearchItems[3].Level);
            Assert.AreEqual(new Vector3(200, 350, 0), controller.ResearchItems[3].Location);

            //Fourth Level
            Assert.IsNotNull(controller.ResearchItems[4]);
            Assert.AreEqual(3, controller.ResearchItems[4].Level);
            Assert.IsNotNull(controller.ResearchItems[5]);
            Assert.AreEqual(4, controller.ResearchItems[5].Level);

            //Fifth Level
            Assert.IsNotNull(controller.ResearchItems[6]);
            Assert.AreEqual(4, controller.ResearchItems[6].Level);
        }

        [TestMethod]
        public void ResearchItemsWithDuplicatesThrowException()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            items.Add(new ResearchItem()
            {
                Name = "A"
            });
            try
            {
                ResearchController controller = new(items);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("Item 'A' exists more than once", ex.Message);
            }
        }

        [TestMethod]
        public void ResearchItemsWithMissingChildThrowException()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            items.Add(new ResearchItem()
            {
                Name = "Z",
                PreReqs = new List<string>() { "X", "Y", "Z" }
            });
            try
            {
                ResearchController controller = new(items);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("Child 'X' not found", ex.Message);
            }
        }

    }
}