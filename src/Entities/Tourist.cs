namespace Entities
{
    public class Tourist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Tourist tourist)
            {
                result = this.Id == tourist.Id;
            }

            return result;
        }
    }
}
