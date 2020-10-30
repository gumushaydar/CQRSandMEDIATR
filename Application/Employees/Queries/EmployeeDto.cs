using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Queries
{
    public class EmployeeDto : IMapFrom<Employee>
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(t => t.EmployeeId, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.FirstName));
        }
    }
}
