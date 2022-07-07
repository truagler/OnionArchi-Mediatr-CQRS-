using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Archi.Domain.Model;

namespace Archi.Application.Service
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task<Book> GetBook(Guid bookId);
        Task<List<Book>> GetBooks();
    }
}