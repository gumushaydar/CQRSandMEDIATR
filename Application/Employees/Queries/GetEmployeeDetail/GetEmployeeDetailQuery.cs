using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery: IRequest<EmployeeDetailViewModel>
    {
        public int Id { get; set; }
    }
}
