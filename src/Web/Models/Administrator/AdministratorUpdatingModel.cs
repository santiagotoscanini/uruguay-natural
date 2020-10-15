using Entities;

namespace Web.Models.AdministratorModel
{
    public class AdministratorUpdatingModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public Administrator ToEntity(string email)
        {
            return new Administrator
            {
                Name = this.Name,
                Password= this.Password,
                Email = email,
            };
        }
    }
}
