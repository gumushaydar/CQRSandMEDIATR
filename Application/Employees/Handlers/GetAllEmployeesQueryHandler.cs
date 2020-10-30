using Application.Employees.Queries;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, EmployeeListViewModel>
    {
        private readonly IMedaitrDBContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IMedaitrDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeListViewModel> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            var vm = new EmployeeListViewModel
            {
                Employees = employees
            };

            return vm;
        }
    }
}
