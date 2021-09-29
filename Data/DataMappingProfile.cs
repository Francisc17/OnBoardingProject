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
            // we do not need to send user password (and we should not send it!)
            CreateMap<User, UserModel>()
                .ForMember(p => p.Password, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Project, ProjectModel>().ReverseMap()
                .ForMember(p => p.ProjectManager, opt => opt.Ignore());

            CreateMap<Entities.Task, TaskModel>()
                .ReverseMap();
        }
    }
}
