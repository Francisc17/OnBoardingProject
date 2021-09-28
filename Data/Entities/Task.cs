using System;
using OnBoardingProject.Data.Enumerations;

namespace OnBoardingProject.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        public TaskState State { get; set; }
        public User TaskResponsible { get; set; }
    }
}
