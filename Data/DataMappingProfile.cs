using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnBoardingProject.Data.Entities;
using OnBoardingProject.Models;

namespace OnBoardingProject.Data
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<Entities.Task, TaskModel>().ReverseMap();
        }
    }
}
