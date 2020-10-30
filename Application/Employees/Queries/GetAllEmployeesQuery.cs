using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Queries
{
   public class GetAllEmployeesQuery : IRequest<EmployeeListViewModel>
    {

    }
}
