using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using Model.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        #region Properties
        private readonly ITicket _ticketService;
        private readonly IMapper _mapper;
        #endregion Properties

        #region Constructor
        public TicketController(ITicket employeeService, IMapper mapper)
        {
            _ticketService = employeeService;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Pulic methods
        //Get all booking offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return Ok(await _ticketService.GetAll());
            //return Ok(_mapper.Map<IEnumerable<TicketDto>>(await _ticketService.GetAll()));
        }

        [HttpGet("ticket")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsWithForeignKey()
        {
            return Ok(await _ticketService.GetAllWithForeignKey());
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Ticket>>> Search(string name)
        {
            return Ok(await _ticketService.Search(name));
        }

        //Update Ticket
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            if (!(await _ticketService.Update(ticket)))
            {
                return NotFound();
            }
            return Ok(await _ticketService.GetById(ticket.Id));
        }

        //Adding new ticket
        [HttpPost]
        public async Task<ActionResult> AddTicket(Ticket ticket)
        {
            await _ticketService.Insert(ticket);

            //return CreatedAtAction("FilterById", new { id = ticket.Id }, ticket);
            return Ok(await _ticketService.GetById(ticket.Id));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            Ticket ticket = await _ticketService.GetById(id);
            if (!(await _ticketService.Exists(id)))
            {
                return NotFound();
            }
            await _ticketService.Delete(ticket);
            return NoContent();
        }
        #endregion Public methods

    }
}
