using System.ComponentModel.DataAnnotations;

namespace Exam1.Model
{
    public class Register
    {
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [EmailAddress]
        public string? email { get; set; }
        [Required]
        [MinLength(6)]
        public string? password { get; set; }
        [Required]
        [Compare("password", ErrorMessage ="Passwoed not a match")]
        public string? cpassword { get; set; }
    }
}
