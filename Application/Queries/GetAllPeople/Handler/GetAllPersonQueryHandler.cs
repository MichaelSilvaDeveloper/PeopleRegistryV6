using Entities.Models;
using Infrastructure.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetAllPeople.Handler
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<Person>>
    {
        private readonly PeopleRegistryDbContext _dBContext;

        public GetAllPersonQueryHandler(PeopleRegistryDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Task<List<Person>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return _dBContext.Person.ToListAsync();
        }
    }
}