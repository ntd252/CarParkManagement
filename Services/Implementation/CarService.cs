﻿using Microsoft.EntityFrameworkCore;
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
    public class CarService : ICar
    {
        #region Properties
        private readonly IGenericRepository<Car> _carRepository;
        #endregion Properties

        #region Constructor
        public CarService(IGenericRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        #endregion Constructor

        #region Public methods

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carRepository.GetAll();
        }

        public async Task<IEnumerable<Car>> GetAllWithForeignKey()
        {
            return await _carRepository.GetAllQuery().Include(c => c.ParkingLot).ToListAsync();
        }


        public async Task<Car> GetById(string licensePlate)
        {
            return await _carRepository.GetByKey(licensePlate);
        }

        public async Task<IEnumerable<Car>> Search(string name)
        {
            var query = _carRepository.GetAllQuery();
            query = query.Where(c => c.Type.Contains(name));
            return await query.ToListAsync();
        }

        public async Task<bool> Update(Car car)
        {
            try
            {
                await _carRepository.Update(car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await Exists(car.LicensePlate)))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            await _carRepository.Save();
            return true;
        }

        public async Task Insert(Car car)
        {
            if (!(await Exists(car.LicensePlate)))
            {
                await _carRepository.Insert(car);
                await _carRepository.Save();
            }
        }

        public async Task Delete(Car car)
        {
            await _carRepository.Delete(car);
            await _carRepository.Save();
        }

        public async Task<bool> Exists(string licensePlate)
        {
            Car car = await _carRepository.GetByKey(licensePlate);
            if (car == null)
                return false;
            else
                return true;
        }

        #endregion Public methods
    }
}
