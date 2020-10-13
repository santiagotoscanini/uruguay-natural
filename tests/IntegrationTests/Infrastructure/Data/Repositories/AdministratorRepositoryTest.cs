using Entities;
using Exceptions;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class AdministratorRepositoryTest
    {
        private IAdministratorRepository _administratorRepository;
        private DbContext _context;

        private string _name = "Buenardo";
        private string _email = "st@mail.com";
        private string _pass = "$3cr3tP@$$";

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
            _context = new TourismContext(options);
            _administratorRepository = new AdministratorRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void AddAdministrator()
        {
            var admin = new Administrator
            {
                Name = _name,
                Email = _email,
                Password = _pass,
            };

            Administrator adminSaved = _administratorRepository.Add(admin);

            Assert.AreEqual(admin, adminSaved);
        }

        [TestMethod]
        public void GetAllAdministrators()
        {
            var admin1 = new Administrator { Name = _name, Email = _email, Password = _pass };
            var admin2 = new Administrator { Name = _name, Email = _email + ".net", Password = _pass };

            var admins = new List<Administrator> { admin1, admin2 };
            admins.ForEach(a => _administratorRepository.Add(a));

            var bookingsSaved = _administratorRepository.GetAll();

            Assert.AreEqual(admin1, bookingsSaved.First());
            Assert.AreEqual(admin2, bookingsSaved.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void AddAlreadyExistBooking()
        {
            var admin1 = new Administrator { Name = _name, Email = _email, Password = _pass };
            var admin2 = new Administrator { Name = _name, Email = _email , Password = _pass };
            _administratorRepository.Add(admin1);
            _administratorRepository.Add(admin2);
        }
    }
}