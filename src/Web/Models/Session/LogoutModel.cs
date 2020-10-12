using System.ComponentModel.DataAnnotations;

namespace Web.Models.Session
{
    public class LogoutModel
    {
        [Required]
        public string Token { get; set; }
    }
}
