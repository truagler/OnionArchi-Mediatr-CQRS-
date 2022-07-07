using System.Threading.Tasks;
using Archi.Domain.Model;
using MediatR;

namespace Archi.Application.Handlers.Commands
{
    public class AddBookCommand: IRequest<Book>
    {
        public Book Book { get; set; }

        public AddBookCommand(Book book)
        {
            Book = book;
        }
    }
}