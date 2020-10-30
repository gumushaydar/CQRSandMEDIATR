using Application.Employees.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IMedaitrDBContext _context;

        public CreateEmployeeCommandHandler(IMedaitrDBContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var entity = new Employee
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            _context.Employees.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
