namespace web
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Book(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}
