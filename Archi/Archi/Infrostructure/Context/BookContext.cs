using System.Threading.Tasks;
using Archi.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Archi.Infrostructure.Context
{
    public sealed class BookContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}