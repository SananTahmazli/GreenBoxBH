using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "full name")]
        public string? FullName { get; set; }
        [Required]
        [Display(Name = "username")]
        public string? Username { get; set; }
        [Required]
        [Display(Name = "email")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "password")]
        [MinLength(8, ErrorMessage = "The password must contain at least 8 characters!")]
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public DateTime BirthDate { get; set; }
    }
}