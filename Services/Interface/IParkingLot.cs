using Model.Entity;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IParkingLot
    {
        public Task<IEnumerable<ParkingLot>> GetAll();
        public Task<ParkingLot> GetById(int id);
        public Task<IEnumerable<ParkingLot>> Search(string name);
        public Task<bool> Update(ParkingLot parkingLot);
        public Task Insert(ParkingLot parkingLot);
        public Task Delete(ParkingLot parkingLot);
        public Task<bool> Exists(int id);
    }
}
