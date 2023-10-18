using Application.Commands.Create.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Create.Request
{
    public class CreatePersonRequest : IRequest<CreatePersonResponse>
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}