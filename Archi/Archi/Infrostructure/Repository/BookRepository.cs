using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archi.Domain.Model;
using Archi.Domain.Service;
using Archi.Infrostructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Archi.Infrostructure.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db)
        {
            _db = db;
        }

        public async Task AddBook(Book book)
        {
            if (book != null)
            {
                await Task.Run(() => _db.Books.AddAsync(book));
            }

            await SaveChanges();
        }

        public async Task UpdateBook(Book book)
        {
            if (book != null && book.Id != null)
            {
                Book bookModel = await _db.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
                bookModel.Name = book.Name;
                book.Author = book.Author;
                book.Genre = book.Genre;
                await SaveChanges();
            }
        }

        private async Task SaveChanges()
        {
            await Task.Run(() => _db.SaveChangesAsync());
        }

        public async Task<Book> GetBook(Guid bookId)
        {
            Book book = new Book();
            
            if (bookId != null)
            {
                Task<ValueTask<Book>> bookModel = await Task.FromResult(Task.Run(() => _db.Books.FindAsync(bookId)));
                if (bookModel.Result.Result != null)
                {
                    book = bookModel.Result.Result;
                }
            }

            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            return Task.FromResult(Task.Run(() => _db.Books)).Result.Result.ToList();
        }
    }
}