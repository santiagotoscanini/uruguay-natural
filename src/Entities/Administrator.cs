namespace Entities
{
    public class Administrator
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Administrator administrator)
            {
                result = this.Email == administrator.Email;
            }

            return result;
        }
    }
}
