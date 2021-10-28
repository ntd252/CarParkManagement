using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBContext;
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
    public class BookingOfficeService : IBookingOffice
    {
        #region Properties
        private readonly IGenericRepository<BookingOffice> _bookingOfficeRepository;
        #endregion Properties

        #region Constructor
        public BookingOfficeService(IGenericRepository<BookingOffice> bookingOfficeRepository)
        {
            _bookingOfficeRepository = bookingOfficeRepository;
        }
        #endregion Constructor

        #region Public methods

        public async Task<IEnumerable<BookingOffice>> GetAll()
        {
            return await _bookingOfficeRepository.GetAll();
        }

        public async Task<IEnumerable<BookingOffice>> GetAllWithForeignKey()
        {
            return await _bookingOfficeRepository.GetAllQuery().Include(b => b.Trip).ToListAsync();
        }


        public async Task<BookingOffice> GetById(int id)
        {
            return await _bookingOfficeRepository.GetById(id);
        }

        public async Task<IEnumerable<BookingOffice>> Search(string name)
        {
            var query = _bookingOfficeRepository.GetAllQuery();
            query = query.Where(b => b.OfficeName.Contains(name));
            return await query.ToListAsync();
        }

        public async Task<bool> Update(BookingOffice bookingOffice)
        {
            try
            {
                await _bookingOfficeRepository.Update(bookingOffice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await Exists(bookingOffice.Id)))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            await _bookingOfficeRepository.Save();
            return true;
        }

        public async Task Insert(BookingOffice bookingOffice)
        {
            BookingOffice bo = new BookingOffice();
            Trip existingTrip = new Trip();
            existingTrip = bookingOffice.Trip;
            bo.Trip = existingTrip;
            
            await _bookingOfficeRepository.Insert(bookingOffice);
            await _bookingOfficeRepository.Save();

        }

        public async Task Delete(BookingOffice bookingOffice)
        {
            await _bookingOfficeRepository.Delete(bookingOffice);
            await _bookingOfficeRepository.Save();
        }

        public async Task<bool> Exists(int id)
        {
            BookingOffice bookingOffice = await _bookingOfficeRepository.GetById(id);
            if (bookingOffice == null)
                return false;
            else
                return true;
        }

        #endregion Public methods

    }
}

