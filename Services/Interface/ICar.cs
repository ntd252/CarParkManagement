using Model.Common;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICar
    {
        public Task<IEnumerable<Car>> GetAll();
        public Task<IEnumerable<Car>> GetAllWithForeignKey();
        public Task<Car> GetById(string licensePlate);
        public Task<IEnumerable<Car>> Search(Request request);
        public Task<bool> Update(Car car);
        public Task Insert(Car car);
        public Task Delete(Car car);
        public Task<bool> Exists(string licensePlate);
    }
}
