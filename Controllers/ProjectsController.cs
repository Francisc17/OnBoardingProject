using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using OnBoardingProject.Data.Entities;
using OnBoardingProject.Models;
using OnBoardingProject.Repositories;
using OnBoardingProject.Repositories.Interfaces;

namespace OnBoardingProject.Controllers
{
    [RoutePrefix("api/users/{id:int}/projects")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository repository, IUserRepository userRepository,
            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [Route()]
        public async Task<IHttpActionResult> Post(int id, ProjectModel model)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);

                if (user != null)
                {

                    //Associate projectManager to project
                    var project = _mapper.Map<Project>(model);
                    project.ProjectManager = user;

                    if (ModelState.IsValid)
                    {
                        _repository.AddProject(project);

                        if (await _repository.SaveChangesAsync())
                        {
                            //TODO: maybe change this return after getProject method implemented
                            return Ok(_mapper.Map<ProjectModel>(project));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);
        }

        [Route()]
        public async Task<IHttpActionResult> Get(int id, bool includeTasks = false)
        {
            try
            {
                var result = await _repository.GetAllUserProjectsAsync(id, includeTasks);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<IEnumerable<ProjectModel>>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{projectId:int}")]
        public async Task<IHttpActionResult> Get(int id, int projectId, bool includeTasks = false)
        {
            try
            {
                var result = await _repository.GetUserProjectAsync(id, projectId, includeTasks);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<ProjectModel>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{projectId}")]
        public async Task<IHttpActionResult> Delete(int id, int projectId)
        {
            try
            {
                var result = await _repository.GetUserProjectAsync(id, projectId);
                if (result == null) return NotFound();

                _repository.DeleteProject(result);

                if(await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{projectId:int}")]
        public async Task<IHttpActionResult> Put(int id, int projectId, ProjectModel model)
        {
            try
            {
                var result = await _repository.GetUserProjectAsync(id, projectId);
                if (result == null) return NotFound();

                _mapper.Map(model, result);


                if (await _repository.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<ProjectModel>(result));
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
