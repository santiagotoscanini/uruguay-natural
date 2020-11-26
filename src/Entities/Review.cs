namespace Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int NumberOfPoints { get; set; }
        
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Review review)
            {
                result = this.Id == review.Id;
            }

            return result;
        }
    }
}