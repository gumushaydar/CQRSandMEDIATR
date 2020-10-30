using Application.Employees.Queries.GetEmployeeDetail;
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
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailViewModel>
    {
        private readonly IMedaitrDBContext _context;
        private readonly IMapper _mapper;
        public GetEmployeeDetailQueryHandler(IMedaitrDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeDetailViewModel> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Employees.Where(t => t.Id == request.Id)
                                             .ProjectTo<EmployeeDetailViewModel>(_mapper.ConfigurationProvider)
                                             .SingleOrDefaultAsync(cancellationToken);

            return vm;
        }
    }
}
