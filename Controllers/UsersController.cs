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

namespace OnBoardingProject.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Post(UserModel model)
        {
            try
            {
                //TODO: verify if user already exists with the future getUser method

                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(model);
                    _repository.AddUser(user);

                    if(await _repository.SaveChangesAsync())
                    {
                        //TODO: maybe change this return after getUser method implemented
                        return Ok(_mapper.Map<UserModel>(user));
                    }
                }
         
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest(ModelState);
        }
    }
}
