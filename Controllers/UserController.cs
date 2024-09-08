using Microsoft.AspNetCore.Mvc;
using Users_Api.Dto;
using Users_Api.Repo;

namespace Users_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost(template: "add_user")]
        public ActionResult AddUser(UserDto userDto) 
        {
            _userRepository.AddUser(userDto);
            return Ok();
        }

        [HttpGet(template: "exists_user")]
        public ActionResult<bool> Exist(string email) 
        {             
          return Ok(_userRepository.ExistsUser(email)); 
        }

        [HttpGet(template: "exists_user_id")]
        public ActionResult<bool> Exist(Guid id)
        {
            return Ok(_userRepository.ExistsUser(id));
        }
    }
}
