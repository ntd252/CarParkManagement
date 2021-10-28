using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IEmployee
    {
        public Task<IEnumerable<Employee>> GetAll();
        public Task<Employee> GetById(int id);
        public Task<IEnumerable<Employee>> Search(string name);
        public Task<bool> Update(Employee employee);
        public Task Insert(Employee employee);
        public Task Delete(Employee employee);
        public Task<bool> Exists(int id);
    }
}
