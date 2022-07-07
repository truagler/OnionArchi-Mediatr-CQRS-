using System;
using System.Threading.Tasks;
using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Queries.GetBook
{
    public class GetBookQuery: IRequest<Task<Book>>
    {
        public Guid Id { get; set; }

        public GetBookQuery(Guid id)
        {
            Id = id;
        }
    }
}