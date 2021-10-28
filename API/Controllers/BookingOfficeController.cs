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
    public class BookingOfficeController : ControllerBase
    {
        #region Properties
        private readonly IBookingOffice _bookingOfficeService;
        private readonly IMapper _mapper;
        #endregion Properties

        #region Constructor
        public BookingOfficeController(IBookingOffice employeeService, IMapper mapper)
        {
            _bookingOfficeService = employeeService;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Pulic methods
        //Get all booking offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingOffice>>> GetBookingOffices()
        {
            return Ok(await _bookingOfficeService.GetAll());
            //return Ok(_mapper.Map<IEnumerable<BookingOfficeDto>>(await _bookingOfficeService.GetAll()));
        }

        [HttpGet("trip")]
        public async Task<ActionResult<IEnumerable<BookingOffice>>> GetBookingOfficesWithTrip()
        {
            return Ok(await _bookingOfficeService.GetAllWithForeignKey());
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<BookingOffice>>> Search(string name)
        {
            return Ok(await _bookingOfficeService.Search(name));
        }

        //Update BookingOffice
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookingOffice(int id, BookingOffice bookingOffice)
        {
            if (id != bookingOffice.Id)
            {
                return BadRequest();
            }

            if (!(await _bookingOfficeService.Update(bookingOffice)))
            {
                return NotFound();
            }
            return Ok(await _bookingOfficeService.GetById(bookingOffice.Id));
        }

        //Adding new bookingOffice
        [HttpPost]
        public async Task<ActionResult> AddBookingOffice(BookingOffice bookingOffice)
        {
            await _bookingOfficeService.Insert(bookingOffice);

            //return CreatedAtAction("FilterById", new { id = bookingOffice.Id }, bookingOffice);
            return Ok(await _bookingOfficeService.GetById(bookingOffice.Id));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingOffice>> DeleteBookingOffice(int id)
        {
            BookingOffice bookingOffice = await _bookingOfficeService.GetById(id);
            if (!(await _bookingOfficeService.Exists(id)))
            {
                return NotFound();
            }
            await _bookingOfficeService.Delete(bookingOffice);
            return NoContent();
        }
        #endregion Public methods

    }
}
