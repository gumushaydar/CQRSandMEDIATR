using Application.Common.Exceptions;
using Application.Employees.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IMedaitrDBContext _context;

        public DeleteEmployeeCommandHandler(IMedaitrDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if(employee == null)
            {
                throw new NotFoundException(nameof(employee), request.Id);
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
