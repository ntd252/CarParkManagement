using Microsoft.EntityFrameworkCore;
using Model.DBContext;
using Model.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CarService : ICar
    {
        #region Properties
        private readonly CarParkDbContext _context;
        #endregion Properties

        #region Constructor
        public CarService(CarParkDbContext context)
        {
            _context = context;
        }
        #endregion Constructor

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public Task<Car> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
