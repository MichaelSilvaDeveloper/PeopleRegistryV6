using Application.Commands.Update.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Update.Request
{
    public class UpdatePersonRequest : IRequest<UpdatePersonResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}