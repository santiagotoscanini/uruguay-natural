using Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.AdministratorModels
{
    public class AdministratorCreatingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public Administrator ToEntity()
        {
            return new Administrator
            {
                Name = Name,
                Email = Email,
                Password = Password,
            };
        }
    }
}
