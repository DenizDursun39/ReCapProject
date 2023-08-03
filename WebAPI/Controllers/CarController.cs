﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int colorId) 
        { 
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId) 
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success) { return Ok( result); }
            return BadRequest(result);
        }

    }
}
