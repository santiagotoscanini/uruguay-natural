using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationCore.Entities;

namespace tests.UnitTests.ApplicationCore.Entities.TouristTests
{
    [TestClass]
    public class CreateTourist
    {
        private string _name = "Juan";
        private string _surname = "Pérez";
        private string _email = "juan.perez@ort.edu.uy";


        [TestMethod]
        public void CreateEmptyTourist()
        {
            Tourist tourist = new Tourist();

            Assert.IsNull(tourist.Name);
            Assert.IsNull(tourist.Surname);
            Assert.IsNull(tourist.Email);
        }

        [TestMethod]
        public void CreateTouristWithData()
        {
            Tourist tourist = new Tourist {
                Name = _name,
                Surname = _surname,
                Email = _email,
            };

            Assert.AreEqual(tourist.Name, _name);
            Assert.AreEqual(tourist.Surname, _surname);
            Assert.AreEqual(tourist.Email, _email);
        }
    }
}
