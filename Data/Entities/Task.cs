using System;
using System.ComponentModel.DataAnnotations;
using OnBoardingProject.Data.Enumerations;

namespace OnBoardingProject.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public DateTime Deadline { get; set; }


        public TaskState State { get; set; } = TaskState.Starting;

        [Required]
        public User TaskResponsible { get; set; }

        [Required]
        public Project Project { get; set; }
    }
}
