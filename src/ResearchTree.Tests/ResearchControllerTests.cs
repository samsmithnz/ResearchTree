using ResearchTree.Models;
using ResearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            List<ResearchItem> list = new()
            {
                ResearchPool.CreateA(),
                ResearchPool.CreateB(),
                ResearchPool.CreateC(),
                ResearchPool.CreateD(),
                ResearchPool.CreateE(),
                ResearchPool.CreateF(),
                ResearchPool.CreateG()
            };
            ResearchController controller = new()
            {
                ResearchItems = list
            };

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
            List<ResearchItem> list = new()
            {
                ResearchPool.CreateA(),
                ResearchPool.CreateB(),
                ResearchPool.CreateC(),
                ResearchPool.CreateD()
            };
            ResearchController controller = new()
            {
                ResearchItems = list
            };

            //Act
            List<ResearchItem> results = controller.GetCompletedResearchItems();

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);
        }

    }
}