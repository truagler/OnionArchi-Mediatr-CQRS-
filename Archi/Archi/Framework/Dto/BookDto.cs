using System;
using Archi.Infrostructure;

namespace Archi.Framework.Dto
{
    public class BookDto
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public GenreBook Genre { get; set; }
        public String Author { get; set; }
        public Boolean IsRemoved { get; set; }
    }
}