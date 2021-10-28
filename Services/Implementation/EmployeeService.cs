using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeService : IEmployee
    {
        #region Properties
        private readonly IGenericRepository<Employee> _employeeRepository;
        #endregion Properties

        #region Constructor
        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion Constructor

        #region Public methods
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<IEnumerable<Employee>> Search(Request request)
        {
            var query = _employeeRepository.GetAllQuery();
            switch (request.Field.ToLower())
            {
                case "name":
                    query = query.Where(e => e.FullName.Contains(request.Keyword));
                    break;
                case "department":
                    query = query.Where(e => e.Department.Contains(request.Keyword));
                    break;
                case "address":
                    query = query.Where(e => e.Address.Contains(request.Keyword));
                    break;
                default:
                    break;
            }
            
            return await query.ToListAsync();
        }

        //public async Task<IEnumerable<Employee>> Search(string name, string department)
        //{
        //    IQueryable<Employee> query = _context.Employees;

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(e => e.FullName == name);
        //    }

        //    if (!string.IsNullOrEmpty(department))
        //    {
        //        query = query.Where(e => e.Department == department);
        //    }

        //    return await query.ToListAsync();
        //}

        public async Task<bool> Update(Employee employee)
        {
            try
            {
                await _employeeRepository.Update(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await Exists(employee.Id)))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            await _employeeRepository.Save();
            return true;            
        }

        public async Task Insert(Employee employee)
        {
            await _employeeRepository.Insert(employee);
            await _employeeRepository.Save();

        }

        public async Task Delete(Employee employee)
        {
            await _employeeRepository.Delete(employee);
            await _employeeRepository.Save();
        }

        public async Task<bool> Exists(int id)
        {
            Employee employee = await _employeeRepository.GetById(id);
            if (employee == null)
                return false;
            else
                return true;
        }

        #endregion Public methods
    }
}
