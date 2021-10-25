using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
    }
}
