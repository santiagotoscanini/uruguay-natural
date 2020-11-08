using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class AdministratorTest
    {
        private string _name = "Buenardo";
        private string _email = "buenardo.rodriguez@ort.edu.uy";
        private string _password = "$3cr3tP@$$";

        [TestMethod]
        public void CreateEmptyAdmin()
        {
            var admin = new Administrator();

            Assert.IsNull(admin.Name);
            Assert.IsNull(admin.Email);
            Assert.IsNull(admin.Password);
        }

        [TestMethod]
        public void CreateAdminWithData()
        {
            var admin = new Administrator
            {
                Name = _name,
                Email = _email,
                Password = _password,
            };

            Assert.AreEqual(admin.Name, _name);
            Assert.AreEqual(admin.Email, _email);
            Assert.AreEqual(admin.Password, _password);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var admin1 = new Administrator
            {
                Name = _name,
                Email = _email,
                Password = _password,
            };
            var admin2 = new Administrator
            {
                Email = _email
            };

            Assert.AreEqual(admin1, admin2);
        }

        [TestMethod]
        public void EqualsFail ()
        {
            var admin1 = new Administrator
            {
                Name = _name,
                Email = _email,
                Password = _password,
            };
            var admin2 = new Administrator
            {
                Email = _email + ".net"
            };

            Assert.AreNotEqual (admin1, admin2);
        }
    }
}