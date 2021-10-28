using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBContext;
using Model.DTO;
using Model.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    #region code1
    /*
    public class EmployeeController : ControllerBase
    {
        #region Properties
        private readonly CarParkDbContext _context;
        #endregion Properties

        #region Constructor
        public EmployeeController(CarParkDbContext context)
        {
            _context = context;
        }
        #endregion Constructor

        //private CarParkDbContext db = new CarParkDbContext();




        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        //Get employee by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        //Update existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //Adding new employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        
    }
    */
    #endregion code1

    public class EmployeeController : ControllerBase
    {
        #region Properties
        private readonly IEmployee _employeeService;
        private readonly IMapper _mapper;
        #endregion Properties

        #region Constructor
        public EmployeeController(IEmployee employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Public methods
        //Get all employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            //return Ok(await _employeeService.GetAll());
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(await _employeeService.GetAll()));
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult> FilterById(int id)
        //{
        //    Employee employee = await _context.GetById(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employee);
        //}


        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name)
        {
            return Ok(await _employeeService.Search(name));
        }

        //Update Employee
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            
            if (!(await _employeeService.Update(employee)))
            {
                return NotFound();
            }
            return Ok(await _employeeService.GetById(employee.Id));
        }
        
        //Adding new employee
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _employeeService.Insert(employee);
            
            //return CreatedAtAction("FilterById", new { id = employee.Id }, employee);
            return Ok(await _employeeService.GetById(employee.Id));
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            Employee employee = await _employeeService.GetById(id);
            if (!(await _employeeService.Exists(id)))
            {
                return NotFound();
            }
            await _employeeService.Delete(employee);
            return NoContent();
        }
        #endregion Public methods
    }
}
