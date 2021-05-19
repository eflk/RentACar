using Bussiness.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            IResult result;
            if (user.Id > 0)
                result = _userService.Update(user);
            else
                result = _userService.Add(user);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (!user.Success || user.Data == null) return BadRequest(user);

            var result = _userService.Delete(user.Data);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
