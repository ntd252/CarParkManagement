using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ITicket
    {
        public Task<IEnumerable<Ticket>> GetAll();
        public Task<IEnumerable<Ticket>> GetAllWithForeignKey();
        public Task<Ticket> GetById(int id);
        public Task<IEnumerable<Ticket>> Search(string name);
        public Task<bool> Update(Ticket ticket);
        public Task Insert(Ticket ticket);
        public Task Delete(Ticket ticket);
        public Task<bool> Exists(int id);
    }
}
