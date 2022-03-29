using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResearchTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ResearchTree.Tests
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L0")]
    public class ResearchControllerTests
    {
        [TestMethod]
        public void ResearchItemsAreCurrentlyWorkedTest()
        {
            //Arrange
            ResearchController controller = new(ResearchPool.BuildDemoList());

            //Act
            List<ResearchItem> results = controller.GetCurrentlyWorkedResearchItems();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void ResearchItemsAreCompletedTest()
        {
            //Arrange
            ResearchController controller = new(ResearchPool.BuildDemoList());

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
            ResearchController controller = new(ResearchPool.BuildDemoList());

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
            Assert.AreEqual(new Vector3(100, 100, 0), controller.ResearchItems[0].Location);
            Assert.AreEqual(0, controller.ResearchItems[0].Edges.Count);

            //Second Level
            Assert.IsNotNull(controller.ResearchItems[1]);
            Assert.AreEqual("B", controller.ResearchItems[1].Name);
            Assert.AreEqual(2, controller.ResearchItems[1].Level);
            Assert.AreEqual(new Vector3(250, 100, 0), controller.ResearchItems[1].Location);
            Assert.AreEqual(1, controller.ResearchItems[1].Edges.Count);
            Assert.AreEqual(new Vector3(100, 100, 0), controller.ResearchItems[1].Edges[0].Item1);
            Assert.AreEqual(new Vector3(250, 100, 0), controller.ResearchItems[1].Edges[0].Item2);

            Assert.IsNotNull(controller.ResearchItems[2]);
            Assert.AreEqual("C", controller.ResearchItems[2].Name);
            Assert.AreEqual(2, controller.ResearchItems[2].Level);
            Assert.AreEqual(new Vector3(250, 250, 0), controller.ResearchItems[2].Location);
            Assert.AreEqual(3, controller.ResearchItems[2].Edges.Count);
            Assert.AreEqual(new Vector3(100, 100, 0), controller.ResearchItems[2].Edges[0].Item1);
            Assert.AreEqual(new Vector3(175, 100, 0), controller.ResearchItems[2].Edges[0].Item2);
            Assert.AreEqual(new Vector3(175, 250, 0), controller.ResearchItems[2].Edges[1].Item1);
            Assert.AreEqual(new Vector3(250, 250, 0), controller.ResearchItems[2].Edges[1].Item2);
            Assert.AreEqual(new Vector3(175, 100, 0), controller.ResearchItems[2].Edges[2].Item1);
            Assert.AreEqual(new Vector3(175, 250, 0), controller.ResearchItems[2].Edges[2].Item2);

            Assert.IsNotNull(controller.ResearchItems[3]);
            Assert.AreEqual("D", controller.ResearchItems[3].Name);
            Assert.AreEqual(2, controller.ResearchItems[3].Level);
            Assert.AreEqual(new Vector3(250, 400, 0), controller.ResearchItems[3].Location);
            Assert.AreEqual(3, controller.ResearchItems[3].Edges.Count);
            Assert.AreEqual(new Vector3(100, 100, 0), controller.ResearchItems[3].Edges[0].Item1);
            Assert.AreEqual(new Vector3(175, 100, 0), controller.ResearchItems[3].Edges[0].Item2);
            Assert.AreEqual(new Vector3(175, 400, 0), controller.ResearchItems[3].Edges[1].Item1);
            Assert.AreEqual(new Vector3(250, 400, 0), controller.ResearchItems[3].Edges[1].Item2);
            Assert.AreEqual(new Vector3(175, 100, 0), controller.ResearchItems[3].Edges[2].Item1);
            Assert.AreEqual(new Vector3(175, 400, 0), controller.ResearchItems[3].Edges[2].Item2);

            //Third Level
            Assert.IsNotNull(controller.ResearchItems[4]);
            Assert.AreEqual("E", controller.ResearchItems[4].Name);
            Assert.AreEqual(3, controller.ResearchItems[4].Level);
            Assert.AreEqual(new Vector3(400, 100, 0), controller.ResearchItems[4].Location);
            Assert.AreEqual(4, controller.ResearchItems[4].Edges.Count);
            Assert.AreEqual(new Vector3(250, 100, 0), controller.ResearchItems[4].Edges[0].Item1);
            Assert.AreEqual(new Vector3(400, 100, 0), controller.ResearchItems[4].Edges[0].Item2);

            Assert.AreEqual(new Vector3(250, 250, 0), controller.ResearchItems[4].Edges[1].Item1);
            Assert.AreEqual(new Vector3(325, 250, 0), controller.ResearchItems[4].Edges[1].Item2);
            Assert.AreEqual(new Vector3(325, 100, 0), controller.ResearchItems[4].Edges[2].Item1);
            Assert.AreEqual(new Vector3(400, 100, 0), controller.ResearchItems[4].Edges[2].Item2);
            Assert.AreEqual(new Vector3(325, 100, 0), controller.ResearchItems[4].Edges[3].Item1);
            Assert.AreEqual(new Vector3(325, 250, 0), controller.ResearchItems[4].Edges[3].Item2);

            ////Fourth Level
            //Assert.IsNotNull(controller.ResearchItems[5]);
            //Assert.AreEqual("F", controller.ResearchItems[5].Name);
            //Assert.AreEqual(4, controller.ResearchItems[5].Level);

            //Assert.IsNotNull(controller.ResearchItems[6]);
            //Assert.AreEqual("G", controller.ResearchItems[6].Name);
            //Assert.AreEqual(4, controller.ResearchItems[6].Level);
            //Assert.AreEqual(new Vector3(550, 250, 0), controller.ResearchItems[6].Location);

            ////Fifth Level
            //Assert.IsNotNull(controller.ResearchItems[7]);
            //Assert.AreEqual("H", controller.ResearchItems[7].Name);
            //Assert.AreEqual(5, controller.ResearchItems[7].Level);
            //Assert.AreEqual(new Vector3(700, 100, 0), controller.ResearchItems[7].Location);
            //Assert.AreEqual(5, controller.ResearchItems[7].Edges.Count);
            //Assert.AreEqual(new Vector3(550, 250, 0), controller.ResearchItems[7].Edges[0].Item1);
            //Assert.AreEqual(new Vector3(675, 250, 0), controller.ResearchItems[7].Edges[0].Item2);
            //Assert.AreEqual(new Vector3(675, 150, 0), controller.ResearchItems[7].Edges[1].Item1);
            //Assert.AreEqual(new Vector3(700, 150, 0), controller.ResearchItems[7].Edges[1].Item2);
            //Assert.AreEqual(new Vector3(675, 250, 0), controller.ResearchItems[7].Edges[2].Item1);
            //Assert.AreEqual(new Vector3(675, 150, 0), controller.ResearchItems[7].Edges[2].Item2);
            //Assert.AreEqual(new Vector3(250, 400, 0), controller.ResearchItems[7].Edges[3].Item1);
            //Assert.AreEqual(new Vector3(675, 400, 0), controller.ResearchItems[7].Edges[3].Item2);
            //Assert.AreEqual(new Vector3(675, 400, 0), controller.ResearchItems[7].Edges[4].Item1);
            //Assert.AreEqual(new Vector3(675, 150, 0), controller.ResearchItems[7].Edges[4].Item2);

            ////Check the number of edges
            //int totalEdges = 0;
            //foreach (ResearchItem item in controller.ResearchItems)
            //{
            //    totalEdges += item.Edges.Count;
            //}
            //Assert.AreEqual(20, totalEdges);
        }

        [TestMethod]
        public void ResearchItemsUnity3DTest()
        {
            //Arrange
            ResearchController controller = new(ResearchPool.BuildDemoList(),
                10, 10, 5, 5);

            //Act

            //Assert
            Assert.IsNotNull(controller.ResearchItems);
            Assert.IsTrue(controller.ResearchItems.Count > 0);

            //First Level
            Assert.IsNotNull(controller.ResearchItems[0]);
            Assert.AreEqual("A", controller.ResearchItems[0].Name);
            Assert.AreEqual(1, controller.ResearchItems[0].Level);
            Assert.AreEqual(new Vector3(10, 10, 0), controller.ResearchItems[0].Location);
            Assert.AreEqual(0, controller.ResearchItems[0].Edges.Count);

            //Second Level
            Assert.IsNotNull(controller.ResearchItems[1]);
            Assert.AreEqual("B", controller.ResearchItems[1].Name);
            Assert.AreEqual(2, controller.ResearchItems[1].Level);
            Assert.AreEqual(new Vector3(25, 10, 0), controller.ResearchItems[1].Location);
            Assert.AreEqual(1, controller.ResearchItems[1].Edges.Count);
            Assert.AreEqual(new Vector3(10, 10, 0), controller.ResearchItems[1].Edges[0].Item1);
            Assert.AreEqual(new Vector3(25, 10, 0), controller.ResearchItems[1].Edges[0].Item2);
        }

        [TestMethod]
        public void ResearchItemsWithDuplicatesThrowExceptionTest()
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
        public void ResearchItemsWithMissingChildThrowExceptionTest()
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

        [TestMethod]
        public void AddTickWithoutWorkersAssignedTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchItem? itemC = items.Where(c => c.Name == "C").FirstOrDefault();
            itemC.WorkersAssigned = 0;
            ResearchController controller = new(items);

            //Act            
            controller.AddTick();

            //Assert
            itemC = controller.ResearchItems.Where(c => c.Name == "C").FirstOrDefault();
            Assert.AreEqual(3, itemC?.WorkCompleted);
            Assert.IsFalse(itemC?.IsComplete);
        }

        [TestMethod]
        public void AddTickWithWorkersAssignedTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchItem? itemC = items.Where(c => c.Name == "C").FirstOrDefault();
            ResearchController controller = new(items);

            //Act            
            controller.AddTick();

            //Assert
            itemC = controller.ResearchItems.Where(c => c.Name == "C").FirstOrDefault();
            Assert.AreEqual(4, itemC?.WorkCompleted);
            Assert.IsFalse(itemC?.IsComplete);

            //Check that ItemE is not enabled as C is not finished.
            List<ResearchItem> availableItems = controller.GetUnstartedResearchItems();
            ResearchItem? itemE = availableItems.Where(c => c.Name == "E").FirstOrDefault();
            Assert.IsNull(itemE);
        }

        [TestMethod]
        public void AddTickWithWorkersAssignedUntilDoneTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchItem? itemC = items.Where(c => c.Name == "C").FirstOrDefault();
            if (itemC != null)
            {
                itemC.WorkCompleted = 19;
            }
            ResearchController controller = new(items);

            //Act            
            controller.AddTick();

            //Assert
            itemC = controller.ResearchItems.Where(c => c.Name == "C").FirstOrDefault();
            Assert.AreEqual(20, itemC?.WorkCompleted);
            Assert.IsTrue(itemC?.IsComplete);

            //Check that ItemE is enabled as C finishes.
            List<ResearchItem> availableItems = controller.GetUnstartedResearchItems();
            ResearchItem? itemE = availableItems.Where(c => c.Name == "E").FirstOrDefault();
            Assert.IsNotNull(itemE);
        }

        [TestMethod]
        public void AssignResearchItemWorkersAndAddTickUntilDoneTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchItem? itemC = items.Where(c => c.Name == "C").FirstOrDefault();
            ResearchController controller = new(items);
            controller.WorkersAvailable = 1;

            //Act
            do
            {
                //Add tickets until the job is done.
                controller.AddTick();
                itemC = controller.ResearchItems.Where(c => c.Name == "C").FirstOrDefault();
            } while (itemC?.IsComplete == false);

            //Assert
            Assert.AreEqual(20, itemC?.WorkCompleted);
            Assert.IsTrue(itemC?.IsComplete);
            Assert.AreEqual(0, itemC?.WorkersAssigned);

            //Check that ItemE is enabled as C finishes.
            List<ResearchItem> availableItems = controller.GetUnstartedResearchItems();
            ResearchItem? itemE = availableItems.Where(c => c.Name == "E").FirstOrDefault();
            Assert.IsNotNull(itemE);
        }

        //Assign multiple workers.

        [TestMethod]
        public void AssignMultipleResearchItemWorkersAndAddTickUntilDoneTest()
        {
            //Arrange
            List<ResearchItem> items = ResearchPool.BuildDemoList();
            ResearchController controller = new(items);
            controller.WorkersAvailable = 2;
            ResearchItem? itemB = items.Where(c => c.Name == "B").FirstOrDefault();
            if (itemB != null)
            {
                itemB.WorkCompleted = 0;
                itemB.WorkersAssigned = 1;
                itemB.IsComplete = false;
            }
            ResearchItem? itemC = items.Where(c => c.Name == "C").FirstOrDefault();

            //Act
            do
            {
                //Add tickets until the job is done.
                controller.AddTick();
                itemB = controller.ResearchItems.Where(c => c.Name == "B").FirstOrDefault();
                itemC = controller.ResearchItems.Where(c => c.Name == "C").FirstOrDefault();
            } while (itemC?.IsComplete == false || itemB?.IsComplete == false);

            //Assert
            Assert.AreEqual(5, itemB?.WorkCompleted);
            Assert.IsTrue(itemB?.IsComplete);
            Assert.AreEqual(0, itemB?.WorkersAssigned);
            Assert.AreEqual(20, itemC?.WorkCompleted);
            Assert.IsTrue(itemC?.IsComplete);
            Assert.AreEqual(0, itemC?.WorkersAssigned);

            //Check that ItemE is enabled as C finishes.
            List<ResearchItem> availableItems = controller.GetUnstartedResearchItems();
            ResearchItem? itemE = availableItems.Where(c => c.Name == "E").FirstOrDefault();
            Assert.IsNotNull(itemE);
        }

    }
}