using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Archi.Application.Service;
using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Queries.GetBook
{
    public class GetBookHandler: IRequestHandler<GetBookQuery, Task<Book>>
    {
        private readonly IBookService _bookService;

        public GetBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Task<Book>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Task.Run(()=> _bookService.GetBook(request.Id).Result, cancellationToken).Result);
        }
    }
}