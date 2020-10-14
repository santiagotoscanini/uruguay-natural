using Entities;

namespace Web.Models.CategoryModels
{
    public class CategoryModel
    {
        public string Name { get; set; }

        public CategoryModel(Category category)
        {
            Name = category.Name;
        }

        public override bool Equals(object obj)
        {
            var Result = false;

            if (obj is CategoryModel category)
            {
                Result = this.Name == category.Name;
            }

            return Result;
        }
    }
}
