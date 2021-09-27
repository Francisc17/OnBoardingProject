﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBoardingProject.Data.Enumerations;

namespace OnBoardingProject.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        public TaskState State { get; set; }
        public Project Project { get; set; }
        public User TaskResponsible { get; set; }
    }
}