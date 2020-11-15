using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class ReviewTest
    {
        private string _text = "Nice place";
        private int _numberOfPoints = 4;
        private int _id = 1;
        private int _otherId = 2;

        [TestMethod]
        public void CreateEmptyReview()
        {
            var review = new Review();
            
            Assert.IsNull(review.Text);
            Assert.AreEqual(0, review.NumberOfPoints);
            Assert.AreEqual(0, review.Id);
        }

        [TestMethod]
        public void CreateReviewWithData()
        {
            var review = new Review
            {
                Id = _id,
                Text = _text,
                NumberOfPoints = _numberOfPoints,
            };
            
            Assert.AreEqual(_text, review.Text);
            Assert.AreEqual(_numberOfPoints, review.NumberOfPoints);
        }
        
        [TestMethod]
        public void EqualsOk()
        {
            var review = new Review
            {
                Id = _id,
                Text = _text,
                NumberOfPoints = _numberOfPoints,
            };
            var review2 = new Review
            {
                Id = _id,
                Text = _text,
                NumberOfPoints = _numberOfPoints,
            };


            Assert.AreEqual(review, review2);
        }

        [TestMethod]
        public void EqualsFail()
        {
            var review = new Review
            {
                Id = _id,
                Text = _text,
                NumberOfPoints = _numberOfPoints,
            };
            var review2 = new Review
            {
                Id = _otherId,
                Text = _text,
                NumberOfPoints = _numberOfPoints,
            };

            Assert.AreNotEqual(review, review2);
        }
    }
}