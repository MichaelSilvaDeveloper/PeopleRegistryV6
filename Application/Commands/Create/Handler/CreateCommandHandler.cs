using Application.Commands.Create.Request;
using Application.Commands.Create.Response;
using Entities.Models;
using Infrastructure.Configuration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Create.Handler
{
    public class CreateCommandHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        private readonly PeopleRegistryDbContext _dBContext;

        public CreateCommandHandler(PeopleRegistryDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var newPerson = new Person
            {
                Name = request.Name,
                Email = request.Email,
            };

            await _dBContext.Person.AddAsync(newPerson, cancellationToken);
            await _dBContext.SaveChangesAsync(cancellationToken);

            return null;
        }
    }
}