using ApplicationCore.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class RegionServiceTest
    {
        private string _regionName1 = "region_name_1";
        private string _regionName2 = "region_name_2";


        [TestMethod]
        public void TestGetAllOk()
        {
            var regionsToReturn = new List<Region>
            {
                new Region
                {
                    Name = _regionName1,
                },
                new Region
                {
                    Name = _regionName2,
                },
            };
            var mock = new Mock<IRegionRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(regionsToReturn);
            var regionService = new RegionService(mock.Object);

            IEnumerable<Region> regionsSaved = regionService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(regionsSaved.SequenceEqual(regionsToReturn));
        }
        
        [TestMethod]
        public void TestGetRegionByNameOk()
        {
            var region = new Region { Name = _regionName1 };
            
            var mock = new Mock<IRegionRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetByName(_regionName1)).Returns(region);
            var regionService = new RegionService(mock.Object);

            Region regionSaved = regionService.GetRegionByName(_regionName1);

            mock.VerifyAll();
            Assert.AreEqual(_regionName1, regionSaved.Name);
        }
    }
}
