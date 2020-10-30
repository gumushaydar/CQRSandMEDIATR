using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
