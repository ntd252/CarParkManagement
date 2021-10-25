using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBContext;
using Model.Entity;
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
        private readonly CarParkDbContext _context;
        #endregion Properties

        #region Constructor
        public BookingOfficeService(CarParkDbContext context)
        {
            _context = context;

        }
        #endregion Constructor

        #region Public methods

        public async Task<IEnumerable<BookingOffice>> GetAll()
        {
            return await _context.BookingOffices.Include(b => b.Trip).ToListAsync();
        }

        public async Task<BookingOffice> GetById(int id)
        {
            BookingOffice bookingOffice = await _context.BookingOffices.FindAsync(id);
            return bookingOffice;
        }

        public async Task<IEnumerable<BookingOffice>> Search(string name, string trip)
        {
            IQueryable<BookingOffice> query = _context.BookingOffices;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(b => b.OfficeName == name);
            }

            return await query.Include(b => b.Trip).ToListAsync();
        }

        public async Task Insert(BookingOffice bookingOffice)
        {
            _context.BookingOffices.Add(bookingOffice);
            await _context.SaveChangesAsync();
        }

        #endregion Public methods

    }
}

