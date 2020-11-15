using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class ReviewTest
    {
        private string _text = "Nice place";
        private int _numberOfPoints = 4;

        [TestMethod]
        public void CreateEmptyReview()
        {
            var review = new Review();
            
            Assert.IsNull(review.Text);
            Assert.AreEqual(0, review.NumberOfPoints);
        }

        [TestMethod]
        public void CreateReviewWithData()
        {
            var review = new Review
            {
                Text = _text,
                NumberOfPoints = _numberOfPoints,
            };
            
            Assert.AreEqual(_text, review.Text);
            Assert.AreEqual(_numberOfPoints, review.NumberOfPoints);
        }
    }
}