using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Entities;
using OnBoardingProject.Data.Enumerations;

namespace OnBoardingProject.Models
{
    public class TaskModel
    {
        [Required]
        [StringLength(30)] //define only max length
        public string TaskName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        [Required]
        public TaskState State { get; set; } = TaskState.Starting;

        [Required]
        public UserModel TaskResponsible { get; set; }
    }
}
