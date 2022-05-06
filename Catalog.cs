using System.Collections.Generic;

namespace web
{
    public class Catalog : ICatalog
    {
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "A química que há entre nós", 10.00m));
            books.Add(new Book(2, "Orgulho e preconceito", 5.00m));

            return books;
        }
    }
}