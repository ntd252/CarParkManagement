using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IBookingOffice
    {
        public Task<IEnumerable<BookingOffice>> GetAll();
        public Task<IEnumerable<BookingOffice>> GetAllWithForeignKey();
        public Task<BookingOffice> GetById(int id);
        public Task<IEnumerable<BookingOffice>> Search(string name);
        public Task<bool> Update(BookingOffice bookingOffice);
        public Task Insert(BookingOffice bookingOffice);
        public Task Delete(BookingOffice bookingOffice);
        public Task<bool> Exists(int id);
    }

}
