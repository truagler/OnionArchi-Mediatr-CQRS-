using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Archi.Domain.Model;
using Archi.Infrostructure;
using MediatR;

namespace Archi.Application.Handlers.Queries
{
    public class GetBooksQuery : IRequest<Task<List<Book>>> { }
}