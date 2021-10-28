using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Common;
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
    public class ParkingLotController : ControllerBase
    {
        #region Properties
        private readonly IParkingLot _parkingLotService;
        private readonly IMapper _mapper;
        #endregion Properties

        #region Constructor
        public ParkingLotController(IParkingLot employeeService, IMapper mapper)
        {
            _parkingLotService = employeeService;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Pulic methods
        //Get all parking lots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingLot>>> GetParkingLots()
        {
            return Ok(await _parkingLotService.GetAll());
            //return Ok(_mapper.Map<IEnumerable<ParkingLotDto>>(await _parkingLotService.GetAll()));
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ParkingLot>>> Search([FromQuery] Request request)
        {
            return Ok(await _parkingLotService.Search(request));
        }

        //Update ParkingLot
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateParkingLot(int id, ParkingLot parkingLot)
        {
            if (id != parkingLot.Id)
            {
                return BadRequest();
            }

            if (!(await _parkingLotService.Update(parkingLot)))
            {
                return NotFound();
            }
            return Ok(await _parkingLotService.GetById(parkingLot.Id));
        }

        //Adding new parkingLot
        [HttpPost]
        public async Task<ActionResult> AddParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotService.Insert(parkingLot);

            //return CreatedAtAction("FilterById", new { id = parkingLot.Id }, parkingLot);
            return Ok(await _parkingLotService.GetById(parkingLot.Id));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingLot>> DeleteParkingLot(int id)
        {
            ParkingLot parkingLot = await _parkingLotService.GetById(id);
            if (!(await _parkingLotService.Exists(id)))
            {
                return NotFound();
            }
            await _parkingLotService.Delete(parkingLot);
            return NoContent();
        }
        #endregion Public methods


    }
}
