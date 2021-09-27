using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardingProject.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int Budget { get; set; }
        public User ProjectManager { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
