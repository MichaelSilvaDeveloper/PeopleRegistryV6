using Application.Commands.Delete.Request;
using Application.Commands.Delete.Response;
using Infrastructure.Configuration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Delete.Handler
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
    {
        private readonly PeopleRegistryDbContext _dbContext;

        public DeletePersonCommandHandler(PeopleRegistryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var getPersonById = await _dbContext.Person.FindAsync(request.Id);
            if (getPersonById == null)
                throw new Exception("Erro ao encontrar pessoa");
            _dbContext.Person.Remove(getPersonById);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return null;
        }
    }
}