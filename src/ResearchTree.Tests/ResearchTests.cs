using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResearchTree.Models;

namespace ResearchTree.Tests
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("L0")]
    public class ResearchTests
    {
        [TestMethod]
        public void ResearchATest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateA();

            //Act            

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual("A", item.Name);
            Assert.AreEqual(0, item.PreReqs.Count);
            Assert.AreEqual(1, item.WorkToComplete);
            Assert.AreEqual(1, item.WorkCompleted);
            Assert.AreEqual(true, item.IsComplete);
        }
        [TestMethod]
        public void ResearchBTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateB();

            //Act            

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual("B", item.Name);
            Assert.AreEqual(1, item.PreReqs.Count);
            Assert.AreEqual(5, item.WorkToComplete);
            Assert.AreEqual(5, item.WorkCompleted);
            Assert.AreEqual(true, item.IsComplete);
        }

        [TestMethod]
        public void ResearchCTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateC();

            //Act            

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual("C", item.Name);
            Assert.AreEqual(1, item.PreReqs.Count);
            Assert.AreEqual(ResearchPool.CreateA().Name, item.PreReqs[0]);
            Assert.AreEqual(20, item.WorkToComplete);
            Assert.AreEqual(3, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

        [TestMethod]
        public void ResearchETest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateE();

            //Act            

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual("E", item.Name);
            Assert.AreEqual(2, item.PreReqs.Count);
            Assert.AreEqual(ResearchPool.CreateB().Name, item.PreReqs[0]);
            Assert.AreEqual(ResearchPool.CreateC().Name, item.PreReqs[1]);
            Assert.AreEqual(50, item.WorkToComplete);
            Assert.AreEqual(0, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

        [TestMethod]
        public void ResearchFTest()
        {
            //Arrange
            ResearchItem item = ResearchPool.CreateF();

            //Act            

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual("F", item.Name);
            Assert.AreEqual(1, item.PreReqs.Count);
            Assert.AreEqual(ResearchPool.CreateE().Name, item.PreReqs[0]);
            Assert.AreEqual(50, item.WorkToComplete);
            Assert.AreEqual(0, item.WorkCompleted);
            Assert.AreEqual(false, item.IsComplete);
        }

    }
}