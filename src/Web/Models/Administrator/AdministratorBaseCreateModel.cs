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
            var Result = false;

            if (obj is AdministratorBaseCreateModel AdministratorModel)
            {
                Result = this.Email == AdministratorModel.Email;
            }

            return Result;
        }
    }
}
