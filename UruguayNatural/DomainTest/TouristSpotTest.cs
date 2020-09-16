using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesLogic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UruguayNaturalTuristico
{
    [TestClass]
    public class TouristSpotTest
    {
        [TestMethod]
        public void CreateTouristSpotValidName() 
        {
            string TouristSpotName = "Cancun";
            string TouristSpotDescription = "This is a description";
            string TouristSpotImage = "This is the image";
            string TouristSpotRegion = Region.PaintedBirdCorridor;
            ICollection<string> TouristSpotFeatures = new HashSet<string> { Feature.City, Feature.Others };
            TouristSpot TouristSpot = new TouristSpot(TouristSpotName, TouristSpotDescription, TouristSpotImage, TouristSpotRegion, TouristSpotFeatures);
            Assert.AreEqual(TouristSpot.Name, TouristSpotName);
        }

        [TestMethod]
        public void CreateTouristSpotValidDescription()
        {
            string TouristSpotName = "Playa bonita";
            string TouristSpotDescription = "This is a description of playa bonita";
            string TouristSpotImage = "This is the image of playa bonita";
            string TouristSpotRegion = Region.SouthCentral;
            ICollection<string> TouristSpotFeatures = new HashSet<string> { Feature.City, Feature.Others };
            TouristSpot TouristSpot = new TouristSpot(TouristSpotName, TouristSpotDescription, TouristSpotImage, TouristSpotRegion, TouristSpotFeatures);
            Assert.AreEqual(TouristSpot.Description, TouristSpotDescription);
        }

        [TestMethod]
        public void CreateTouristSpotValidImage()
        {
            string TouristSpotName = "Cabo polonio";
            string TouristSpotDescription = "This is a description of cabo polonio";
            string TouristSpotImage = "This is the image of cabo polonio";
            string TouristSpotRegion = Region.Metropolitan;
            ICollection<string> TouristSpotFeatures = new HashSet<string> { Feature.Villages };
            TouristSpot TouristSpot = new TouristSpot(TouristSpotName, TouristSpotDescription, TouristSpotImage, TouristSpotRegion, TouristSpotFeatures);
            Assert.AreEqual(TouristSpot.Image, TouristSpotImage);
        }

        [TestMethod]
        public void CreateTouristSpotValidRegion()
        {
            string TouristSpotName = "Punta del este";
            string TouristSpotDescription = "This is a description of pde";
            string TouristSpotImage = "This is the image of pde";
            string TouristSpotRegion = Region.East;
            ICollection<string> TouristSpotFeatures = new HashSet<string> { Feature.ProtectedAreas };
            TouristSpot TouristSpot = new TouristSpot(TouristSpotName, TouristSpotDescription, TouristSpotImage, TouristSpotRegion, TouristSpotFeatures);
            Assert.AreEqual(TouristSpot.Region, TouristSpotRegion);
        }

        [TestMethod]
        public void CreateTouristSpotValidFeatures()
        {
            string TouristSpotName = "Punta del este";
            string TouristSpotDescription = "This is a description of pde";
            string TouristSpotImage = "This is the image of pde";
            string TouristSpotRegion = Region.East;
            ICollection<string> TouristSpotFeatures = new HashSet<string> {Feature.City};
            TouristSpot TouristSpot = new TouristSpot(TouristSpotName, TouristSpotDescription, TouristSpotImage, TouristSpotRegion, TouristSpotFeatures);
            Assert.AreEqual(TouristSpot.Features, TouristSpotFeatures);
        }
    }
}
