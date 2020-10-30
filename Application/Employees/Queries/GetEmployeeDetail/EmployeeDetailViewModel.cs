using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Queries.GetEmployeeDetail
{
    public class EmployeeDetailViewModel : IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailViewModel>()
                   .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
