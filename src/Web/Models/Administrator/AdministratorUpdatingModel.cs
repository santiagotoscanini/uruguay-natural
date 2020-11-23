using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.Models.AdministratorModel
{
    public class AdministratorUpdatingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
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
