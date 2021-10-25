using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBContext;
using Model.Entity;
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
        private readonly CarParkDbContext _context;
        #endregion Properties

        #region Constructor
        public EmployeeService(CarParkDbContext context)
        {
            _context = context;

        }
        #endregion Constructor

        #region Public methods
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> Search(string name, string department)
        {
            IQueryable<Employee> query = _context.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FullName == name);
            }

            if (!string.IsNullOrEmpty(department))
            {
                query = query.Where(e => e.Department == department);
            }

            return await query.ToListAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            

           await _context.SaveChangesAsync();
            
        }

        public async Task Insert(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        #endregion Public methods
    }
}
