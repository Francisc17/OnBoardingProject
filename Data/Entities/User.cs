using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Enumerations;

namespace OnBoardingProject.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public UserType UserType { get; set; }
    }
}
