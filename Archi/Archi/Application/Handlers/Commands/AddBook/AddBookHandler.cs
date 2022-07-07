using System.Threading;
using System.Threading.Tasks;
using Archi.Application.Service;
using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Commands
{
    public class AddBookHandler: IRequestHandler<AddBookCommand, Book>
    {
        private readonly IBookService _bookService;

        public AddBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        { 
            await _bookService.AddBook(request.Book);

            return null;
        }
    }
}