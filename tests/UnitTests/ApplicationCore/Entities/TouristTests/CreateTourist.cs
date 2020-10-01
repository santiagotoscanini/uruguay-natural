using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationCore.Entities;

namespace tests.UnitTests.ApplicationCore.Entities.TouristTests
{
    [TestClass]
    public class CreateTourist
    {
        string _name = "Juan";
        string _surname = "Pérez";
        string _email = "juan.perez@ort.edu.uy";


        [TestMethod]
        public void CreateEmptyTourist()
        {
            Tourist tourist = new Tourist();

            Assert.AreEqual(tourist.Name, null);
            Assert.AreEqual(tourist.Surname, null);
            Assert.AreEqual(tourist.Email, null);
        }

        [TestMethod]
        public void CreateTouristWithData()
        {
            Tourist tourist = new Tourist { Name = _name, Surname = _surname, Email = _email };

            Assert.AreEqual(tourist.Name, _name);
            Assert.AreEqual(tourist.Surname, _surname);
            Assert.AreEqual(tourist.Email, _email);
        }
    }
}
