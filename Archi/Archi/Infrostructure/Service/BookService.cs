using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archi.Application.Service;
using Archi.Domain.Model;
using Archi.Domain.Service;

namespace Archi.Infrostructure.Service
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBook(Book book)
        {
            book.Id = Guid.NewGuid();
            
            await Task.Run(() => _bookRepository.AddBook(book));
        }

        public async Task UpdateBook(Book book)
        {
            await Task.Run(() => _bookRepository.UpdateBook(book));
        }

        public async Task<Book> GetBook(Guid bookId)
        {
            return Task.FromResult(Task.Run(() => _bookRepository.GetBook(bookId)).Result).Result;
        }

        public async Task<List<Book>> GetBooks()
        {
            return Task.FromResult(Task.Run(() => _bookRepository.GetBooks().Result)).Result.Result;
        }
    }
}