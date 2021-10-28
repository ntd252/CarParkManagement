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
    public class TripController : ControllerBase
    {
        #region Properties
        private readonly ITrip _tripService;
        private readonly IMapper _mapper;
        #endregion Properties

        #region Constructor
        public TripController(ITrip employeeService, IMapper mapper)
        {
            _tripService = employeeService;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Pulic methods
        //Get all booking offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return Ok(await _tripService.GetAll());
            //return Ok(_mapper.Map<IEnumerable<TripDto>>(await _tripService.GetAll()));
        }


        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Trip>>> Search(string name)
        {
            return Ok(await _tripService.Search(name));
        }

        //Update Trip
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTrip(int id, Trip trip)
        {
            if (id != trip.Id)
            {
                return BadRequest();
            }

            if (!(await _tripService.Update(trip)))
            {
                return NotFound();
            }
            return Ok(await _tripService.GetById(trip.Id));
        }

        //Adding new trip
        [HttpPost]
        public async Task<ActionResult> AddTrip(Trip trip)
        {
            await _tripService.Insert(trip);

            //return CreatedAtAction("FilterById", new { id = trip.Id }, trip);
            return Ok(await _tripService.GetById(trip.Id));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Trip>> DeleteTrip(int id)
        {
            Trip trip = await _tripService.GetById(id);
            if (!(await _tripService.Exists(id)))
            {
                return NotFound();
            }
            await _tripService.Delete(trip);
            return NoContent();
        }
        #endregion Public methods
    }
}
