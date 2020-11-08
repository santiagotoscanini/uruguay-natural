namespace Entities
{
    public class Guest
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public int MinRankAge { get; set; }
        public int MaxRankAge { get; set; }
        
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Guest guest)
            {
                result = this.Name == guest.Name;
            }

            return result;
        }
    }
}