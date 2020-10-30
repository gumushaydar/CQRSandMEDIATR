using Application.Common.Exceptions;
using Application.Employees.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IMedaitrDBContext _context;

        public UpdateEmployeeCommandHandler(IMedaitrDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if(employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Age = request.Age;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
