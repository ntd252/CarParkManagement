using Model.Common;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ITrip
    {
        public Task<IEnumerable<Trip>> GetAll();
        public Task<Trip> GetById(int id);
        public Task<IEnumerable<Trip>> Search(Request request);
        public Task<bool> Update(Trip trip);
        public Task Insert(Trip trip);
        public Task Delete(Trip trip);
        public Task<bool> Exists(int id);
    }
}
