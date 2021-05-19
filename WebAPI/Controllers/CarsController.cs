using Bussiness.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getAllCarInfos")]
        public IActionResult GetCarInfos()
        {
            var result = _carService.GetCarInfos();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            IResult result;
            if (car.Id > 0)
                result = _carService.Update(car);
            else
                result = _carService.Add(car);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var car = _carService.GetById(id);
            if (!car.Success || car.Data == null) return BadRequest(car);

            var result = _carService.Delete(car.Data);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
