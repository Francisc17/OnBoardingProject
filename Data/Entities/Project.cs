using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProject.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int Budget { get; set; }
        [Required]
        public User ProjectManager { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
