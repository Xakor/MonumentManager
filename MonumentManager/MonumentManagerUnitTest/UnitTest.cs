using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MonumentManager.Model;

namespace MonumentManagerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public MonumentManager.Model.SculptureModel Sculpture { get; set; }
        public string Name { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Sculpture = new SculptureModel();
        }

        [TestMethod]
        public void TestName()
        {
            // Arrange
            Name = "Yngling til hest";

            // Act
            Sculpture.Name = Name;

            // Assert
            Assert.AreEqual(Name, Sculpture.Name);

        }

        [TestMethod]
        public void TestEmptyName()
        {
            // Arrange
            Name = String.Empty;

            // Act
            Action action = () => Sculpture.Name = Name;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

    }
}