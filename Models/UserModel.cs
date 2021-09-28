using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Enumerations;

namespace OnBoardingProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }

        [RegularExpression("(9[1236][0-9]) ?([0-9]{3}) ?([0-9]{3})", 
            ErrorMessage = "Invalid Mobile Number.")]
        public int PhoneNumber { get; set; }

        [Required]
        public UserType UserType { get; set; }
    }
}
