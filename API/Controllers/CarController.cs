using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        #region Properties
        private readonly ICar _carService;
        private readonly IMapper _mapper;
        #endregion Properties

        #region Constructor
        public CarController(ICar employeeService, IMapper mapper)
        {
            _carService = employeeService;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Pulic methods
        //Get all cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return Ok(await _carService.GetAll());
            //return Ok(_mapper.Map<IEnumerable<CarDto>>(await _carService.GetAll()));
        }

        [HttpGet("parkinglot")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarsWithParkingLot()
        {
            return Ok(await _carService.GetAllWithForeignKey());
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Car>>> Search(string name)
        {
            return Ok(await _carService.Search(name));
        }

        //Update Car
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCar(string licensePlate, Car car)
        {
            if (licensePlate != car.LicensePlate)
            {
                return BadRequest();
            }

            if (!(await _carService.Update(car)))
            {
                return NotFound();
            }
            return Ok(await _carService.GetById(car.LicensePlate));
        }

        //Adding new car
        [HttpPost]
        public async Task<ActionResult> AddCar(Car car)
        {
            await _carService.Insert(car);

            //return CreatedAtAction("FilterById", new { id = car.Id }, car);
            return Ok(await _carService.GetById(car.LicensePlate));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(string licensePlate)
        {
            Car car = await _carService.GetById(licensePlate);
            if (!(await _carService.Exists(licensePlate)))
            {
                return NotFound();
            }
            await _carService.Delete(car);
            return NoContent();
        }
        #endregion Public methods

    }
}
