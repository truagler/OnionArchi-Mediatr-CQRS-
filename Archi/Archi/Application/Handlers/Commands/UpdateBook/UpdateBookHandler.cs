using System.Threading;
using System.Threading.Tasks;
using Archi.Application.Service;
using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Commands.UpdateBook
{
    public class UpdateBookHandler: IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookService _bookService;

        public UpdateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        { 
            await _bookService.UpdateBook(request.Book);

            return null;
        }
    }
}