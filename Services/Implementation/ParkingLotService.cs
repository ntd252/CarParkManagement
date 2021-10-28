using Microsoft.EntityFrameworkCore;
using Model.Common;
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
    public class ParkingLotService : IParkingLot
    {
        #region Properties
        private readonly IGenericRepository<ParkingLot> _parkingLotRepository;
        #endregion Properties

        #region Constructor
        public ParkingLotService(IGenericRepository<ParkingLot> parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }
        #endregion Constructor

        #region Public methods

        public async Task<IEnumerable<ParkingLot>> GetAll()
        {
            return await _parkingLotRepository.GetAll();
        }

        public async Task<ParkingLot> GetById(int id)
        {
            return await _parkingLotRepository.GetById(id);
        }

        public async Task<IEnumerable<ParkingLot>> Search(Request request)
        {
            var query = _parkingLotRepository.GetAllQuery();
            switch (request.Field.ToLower())
            {
                case "name":
                    query = query.Where(b => b.Name.Contains(request.Keyword));
                    break;
                case "place":
                    query = query.Where(b => b.Place.Contains(request.Keyword));
                    break;
                case "area":
                    query = query.Where(b => b.Area.Contains(request.Keyword));
                    break;
                default:
                    return null;
            }

            return await query.ToListAsync();
        }

        public async Task<bool> Update(ParkingLot parkingLot)
        {
            try
            {
                await _parkingLotRepository.Update(parkingLot);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await Exists(parkingLot.Id)))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            await _parkingLotRepository.Save();
            return true;
        }

        public async Task Insert(ParkingLot parkingLot)
        {
            await _parkingLotRepository.Insert(parkingLot);
            await _parkingLotRepository.Save();

        }

        public async Task Delete(ParkingLot parkingLot)
        {
            await _parkingLotRepository.Delete(parkingLot);
            await _parkingLotRepository.Save();
        }

        public async Task<bool> Exists(int id)
        {
            ParkingLot parkingLot = await _parkingLotRepository.GetById(id);
            if (parkingLot == null)
                return false;
            else
                return true;
        }

        #endregion Public methods
    }
}
