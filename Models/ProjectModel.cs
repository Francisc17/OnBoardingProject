using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;

namespace OnBoardingProject.Models
{
    public class ProjectModel
    {
        [Required]
        [StringLength(30)]
        public string ProjectName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Budget { get; set; }

        [Required]
        public UserModel ProjectManager { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }
}
