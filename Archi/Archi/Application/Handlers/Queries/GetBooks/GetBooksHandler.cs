using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Archi.Application.Handlers.Queries;
using Archi.Application.Service;
using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Commands
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, Task<List<Book>>>
    {
        private readonly IBookService _bookService;

        public GetBooksHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Task<List<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Task.Run(()=> _bookService.GetBooks().Result, cancellationToken).Result);
        }
    }
}