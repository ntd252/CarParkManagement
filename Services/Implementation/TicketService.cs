using Microsoft.EntityFrameworkCore;
using Model.Entity;
using Model.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TicketService : ITicket
    {
        #region Properties
        private readonly IGenericRepository<Ticket> _ticketRepository;
        #endregion Properties

        #region Constructor
        public TicketService(IGenericRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        #endregion Constructor

        #region Public methods

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _ticketRepository.GetAll();
        }

        public async Task<IEnumerable<Ticket>> GetAllWithForeignKey()
        {
            var query = _ticketRepository.GetAllQuery();
            query = query.Include(t => t.CarLicensePlate);
            query = query.Include(t => t.Trip);

            return await query.ToListAsync();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _ticketRepository.GetById(id);
        }

        public async Task<IEnumerable<Ticket>> Search(string name)
        {
            var query = _ticketRepository.GetAllQuery();
            query = query.Where(t => t.CustomerName.Contains(name));
            return await query.ToListAsync();
        }

        public async Task<bool> Update(Ticket ticket)
        {
            try
            {
                await _ticketRepository.Update(ticket);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await Exists(ticket.Id)))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            await _ticketRepository.Save();
            return true;
        }

        public async Task Insert(Ticket ticket)
        {
            await _ticketRepository.Insert(ticket);
            await _ticketRepository.Save();

        }

        public async Task Delete(Ticket ticket)
        {
            await _ticketRepository.Delete(ticket);
            await _ticketRepository.Save();
        }

        public async Task<bool> Exists(int id)
        {
            Ticket ticket = await _ticketRepository.GetById(id);
            if (ticket == null)
                return false;
            else
                return true;
        }

        #endregion Public methods
    }
}
