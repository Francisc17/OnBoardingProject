﻿using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using OnBoardingProject.Data.Entities;

namespace OnBoardingProject.App_Start
{
    public class AutofaConfig
    {
        public class AutofacConfig
        {
            public static void Register()
            {
                var bldr = new ContainerBuilder();
                var config = GlobalConfiguration.Configuration;
                bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
                RegisterServices(bldr);
                bldr.RegisterWebApiFilterProvider(config);
                bldr.RegisterWebApiModelBinderProvider();
                var container = bldr.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            }

            private static void RegisterServices(ContainerBuilder bldr)
            {
                /*
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new CampMappingProfile());
                });
                

                bldr.RegisterInstance(config.CreateMapper())
                          .As<IMapper>()
                          .SingleInstance();
                */

                bldr.RegisterType<OnBoardingDbContext>()
                  .InstancePerRequest();

                /*
                bldr.RegisterType<CampRepository>()
                  .As<ICampRepository>()
                  .InstancePerRequest();
                */
               
            }
        }
    }
}