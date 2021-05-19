using Bussiness.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            IResult result;
            if (color.Id > 0)
                result = _colorService.Update(color);
            else
                result = _colorService.Add(color);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var color = _colorService.GetById(id);
            if (!color.Success || color.Data == null) return BadRequest(color);

            var result = _colorService.Delete(color.Data);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
