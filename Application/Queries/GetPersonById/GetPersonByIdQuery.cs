using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
    }
}