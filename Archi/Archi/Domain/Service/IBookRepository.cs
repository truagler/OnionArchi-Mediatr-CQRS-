using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Archi.Domain.Model;

namespace Archi.Domain.Service
{
    public interface IBookRepository
    {
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task<Book> GetBook(Guid bookId);
        Task<List<Book>> GetBooks();
    }
}