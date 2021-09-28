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
        //TODO: review endpoints (email or id?)

        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("{id:int}", Name = "GetUser")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.GetUserByIdAsync(id);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<UserModel>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [Route()]
        public async Task<IHttpActionResult> Post(UserModel model)
        {
            try
            {
                if (await _repository.GetUserByEmailAsync(model.Email) != null)
                    ModelState.AddModelError("Email", "Email already in use");

                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(model);
                    _repository.AddUser(user);

                    if(await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<UserModel>(user);

                        //TODO: maybe change this return after getUser method implemented
                        return CreatedAtRoute("GetUser", new { id = newModel.Id }, newModel);
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
