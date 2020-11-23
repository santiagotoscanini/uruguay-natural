using System.ComponentModel.DataAnnotations;

namespace Web.Models.ImporterModel
{
    public class ImporterBaseModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string FilePath { get; set; }
    }
}