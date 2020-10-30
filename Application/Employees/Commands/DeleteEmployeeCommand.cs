using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
