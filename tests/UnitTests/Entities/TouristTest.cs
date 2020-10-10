using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace tests.UnitTests.Entities
{
    [TestClass]
    public class TouristTest
    {
        private string _name = "Juan";
        private string _surname = "Pérez";
        private string _email = "juan.perez@ort.edu.uy";

        [TestMethod]
        public void CreateEmptyTourist()
        {
            Tourist tourist = new Tourist();

            Assert.AreEqual(0, tourist.Id);
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

        [TestMethod]
        public void EqualsOk()
        {
            Tourist tourist1 = new Tourist
            {
                Id = 1,
                Name = _name,
                Surname = _surname,
                Email = _email,
            };

            Tourist tourist2 = new Tourist
            {
                Id = 1
            };

            Assert.AreEqual(tourist1, tourist2);
        }

        [TestMethod]
        public void EqualsFail()
        {
            Tourist tourist1 = new Tourist
            {
                Id = 1,
                Name = _name,
                Surname = _surname,
                Email = _email,
            };

            Tourist tourist2 = new Tourist
            {
                Id = 2
            };

            Assert.AreNotEqual(tourist1, tourist2);
        }
    }
}
