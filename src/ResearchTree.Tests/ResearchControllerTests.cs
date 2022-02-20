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
            Assert.AreEqual("A", controller.ResearchItems[0].Name);
            Assert.AreEqual(1, controller.ResearchItems[0].Level);
            Assert.AreEqual(new Vector3(50, 50, 0), controller.ResearchItems[0].Location);
            Assert.AreEqual(0, controller.ResearchItems[0].Edges.Count);

            //Second Level
            Assert.IsNotNull(controller.ResearchItems[1]);
            Assert.AreEqual("B", controller.ResearchItems[1].Name);
            Assert.AreEqual(2, controller.ResearchItems[1].Level);
            Assert.AreEqual(new Vector3(200, 50, 0), controller.ResearchItems[1].Location);
            Assert.AreEqual(1, controller.ResearchItems[1].Edges.Count);
            Assert.AreEqual(new Vector3(150, 100, 0), controller.ResearchItems[1].Edges[0].Item1);
            Assert.AreEqual(new Vector3(200, 100, 0), controller.ResearchItems[1].Edges[0].Item2);

            Assert.IsNotNull(controller.ResearchItems[2]);
            Assert.AreEqual("C", controller.ResearchItems[2].Name);
            Assert.AreEqual(2, controller.ResearchItems[2].Level);
            Assert.AreEqual(new Vector3(200, 200, 0), controller.ResearchItems[2].Location);

            Assert.IsNotNull(controller.ResearchItems[3]);
            Assert.AreEqual("D", controller.ResearchItems[3].Name);
            Assert.AreEqual(2, controller.ResearchItems[3].Level);
            Assert.AreEqual(new Vector3(200, 350, 0), controller.ResearchItems[3].Location);

            //Third Level
            Assert.IsNotNull(controller.ResearchItems[4]);
            Assert.AreEqual("E", controller.ResearchItems[4].Name);
            Assert.AreEqual(3, controller.ResearchItems[4].Level);

            //Fourth Level
            Assert.IsNotNull(controller.ResearchItems[5]);
            Assert.AreEqual("F", controller.ResearchItems[5].Name);
            Assert.AreEqual(4, controller.ResearchItems[5].Level);

            Assert.IsNotNull(controller.ResearchItems[6]);
            Assert.AreEqual("G", controller.ResearchItems[6].Name);
            Assert.AreEqual(4, controller.ResearchItems[6].Level);
            Assert.AreEqual(new Vector3(500, 200, 0), controller.ResearchItems[6].Location);

            //Fifth Level
            Assert.IsNotNull(controller.ResearchItems[7]);
            Assert.AreEqual("H", controller.ResearchItems[7].Name);
            Assert.AreEqual(5, controller.ResearchItems[7].Level);
            Assert.AreEqual(new Vector3(650, 50, 0), controller.ResearchItems[7].Location);
            Assert.AreEqual(5, controller.ResearchItems[7].Edges.Count);
            Assert.AreEqual(new Vector3(600, 250, 0), controller.ResearchItems[7].Edges[0].Item1);
            Assert.AreEqual(new Vector3(625, 250, 0), controller.ResearchItems[7].Edges[0].Item2);
            Assert.AreEqual(new Vector3(625, 100, 0), controller.ResearchItems[7].Edges[1].Item1);
            Assert.AreEqual(new Vector3(650, 100, 0), controller.ResearchItems[7].Edges[1].Item2);
            Assert.AreEqual(new Vector3(625, 250, 0), controller.ResearchItems[7].Edges[2].Item1);
            Assert.AreEqual(new Vector3(625, 100, 0), controller.ResearchItems[7].Edges[2].Item2);
            Assert.AreEqual(new Vector3(300, 400, 0), controller.ResearchItems[7].Edges[3].Item1);
            Assert.AreEqual(new Vector3(625, 400, 0), controller.ResearchItems[7].Edges[3].Item2);
            Assert.AreEqual(new Vector3(625, 400, 0), controller.ResearchItems[7].Edges[4].Item1);
            Assert.AreEqual(new Vector3(625, 100, 0), controller.ResearchItems[7].Edges[4].Item2);

            //Check the number of edges
            int totalEdges = 0;
            foreach (ResearchItem item in controller.ResearchItems)
            {
                totalEdges += item.Edges.Count;
            }
            Assert.AreEqual(20, totalEdges);

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