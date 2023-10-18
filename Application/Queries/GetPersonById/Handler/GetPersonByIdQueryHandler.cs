using Entities.Models;
using Infrastructure.Configuration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetPersonById.Handler
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly PeopleRegistryDbContext _dbContext;

        public GetPersonByIdQueryHandler(PeopleRegistryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var getPersonById = await _dbContext.Person.FindAsync(request.Id);
            if (getPersonById == null)
                throw new Exception("Não encontrado");
            return getPersonById;
        }
    }
}
