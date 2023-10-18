using Application.Commands.Delete.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Delete.Request
{
    public class DeletePersonRequest : IRequest<DeletePersonResponse>
    {
        public int Id { get; set; }
    }
}