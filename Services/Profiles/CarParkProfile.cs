using AutoMapper;
using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Profiles
{
    public class CarParkProfile : Profile
    {
        public CarParkProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
