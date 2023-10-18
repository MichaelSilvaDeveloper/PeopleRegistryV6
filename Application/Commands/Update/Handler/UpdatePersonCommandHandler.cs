using Application.Commands.Update.Request;
using Application.Commands.Update.Response;
using Entities.Models;
using Infrastructure.Configuration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Update.Handler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
    {
        private readonly PeopleRegistryDbContext _dBContext;

        public UpdatePersonCommandHandler(PeopleRegistryDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var getPersonById = await _dBContext.Person.FindAsync(request.Id);
            if (getPersonById == null)
                throw new Exception("Erro ao encontrar pessoa");
            getPersonById.Name = request.Name;
            _dBContext.Person.Update(getPersonById);
            await _dBContext.SaveChangesAsync(cancellationToken);

            return null;
        }
    }
}