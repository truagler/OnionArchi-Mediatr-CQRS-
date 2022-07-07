using System;
using System.Net;
using Archi.Infrostructure;

namespace Archi.Domain.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public GenreBook Genre { get; set; }
        public String Author { get; set; }
        public Boolean IsRemoved { get; set; }

        public Book() { }

        public Book(Guid id, String name, GenreBook genre, String author, Boolean isRemoved)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Author = author;
            IsRemoved = isRemoved;
        }
    }
}