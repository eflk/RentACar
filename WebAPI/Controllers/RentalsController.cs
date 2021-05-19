using Bussiness.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("listAllRentals")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("rentACar")]
        public IActionResult RentACar(Rental rental)
        {
            var result = _rentalService.RentACar(rental);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("returnACar")]
        public IActionResult ReturnACar(Rental rental)
        {
            var result = _rentalService.ReturnACar(rental);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


    }
}
