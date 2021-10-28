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
    public class TripService : ITrip
    {
        #region Properties
        private readonly IGenericRepository<Trip> _tripRepository;
        #endregion Properties

        #region Constructor
        public TripService(IGenericRepository<Trip> tripRepository)
        {
            _tripRepository = tripRepository;
        }
        #endregion Constructor

        #region Public methods

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _tripRepository.GetAll();
        }

        public async Task<Trip> GetById(int id)
        {
            return await _tripRepository.GetById(id);
        }

        public async Task<IEnumerable<Trip>> Search(Request request)
        {
            var query = _tripRepository.GetAllQuery();
            switch (request.Field.ToLower())
            {
                case "destination":
                    query = query.Where(b => b.Destination.Contains(request.Keyword.ToLower()));
                    break;
                case "driver":
                    query = query.Where(b => b.Driver.Contains(request.Keyword.ToLower()));
                    break;
                case "departure":
                    query = query.Where(b => b.DepartureDate.Date == request.Date.Date);
                    break;
                default:
                    return null;
            }

            return await query.ToListAsync();
        }

        public async Task<bool> Update(Trip trip)
        {
            try
            {
                await _tripRepository.Update(trip);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await Exists(trip.Id)))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            await _tripRepository.Save();
            return true;
        }

        public async Task Insert(Trip trip)
        {
            await _tripRepository.Insert(trip);
            await _tripRepository.Save();

        }

        public async Task Delete(Trip trip)
        {
            await _tripRepository.Delete(trip);
            await _tripRepository.Save();
        }

        public async Task<bool> Exists(int id)
        {
            Trip trip = await _tripRepository.GetById(id);
            if (trip == null)
                return false;
            else
                return true;
        }

        #endregion Public methods

    }
}
