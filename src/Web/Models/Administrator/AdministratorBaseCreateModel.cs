using Entities;

namespace Web.Models.AdministratorModels
{
    public class AdministratorBaseCreateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public AdministratorBaseCreateModel(Administrator admin)
        {
            this.Name = admin.Name;
            this.Email = admin.Email;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is AdministratorBaseCreateModel administratorModel)
            {
                result = this.Email == administratorModel.Email;
            }

            return result;
        }
    }
}
