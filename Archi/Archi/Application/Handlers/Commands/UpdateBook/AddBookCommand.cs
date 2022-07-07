using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Commands.UpdateBook
{
    public class UpdateBookCommand: IRequest<Book>
    {
        public Book Book { get; set; }

        public UpdateBookCommand(Book book)
        {
            Book = book;
        }
    }
}