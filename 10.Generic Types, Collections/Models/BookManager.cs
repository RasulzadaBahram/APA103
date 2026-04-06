namespace _10.Generic_Types__Collections.Models
{
    internal class BookManager
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public Dictionary<string, List<Book>> BooksByAuthor { get; set; } = new Dictionary<string, List<Book>>();
        public Queue<Book> WaitingQueue { get; set; } = new Queue<Book>();
        public Stack<Book> RecentlyReturned { get; set; } = new Stack<Book>();



        public void AddBook(Book book)
        {
            Books.Add(book);
            if (BooksByAuthor.ContainsKey(book.Author))
            {
                BooksByAuthor[book.Author] = new List<Book>();
            }
            BooksByAuthor[book.Author].Add(book);
        }

        public Book SearchByTitle(string title)
        {
            foreach (var book in Books)
            {
                if (book.Title == title)
                {
                    return book;
                }
            }
            return null;
        }
        //public Book GetBooksByAuthor(string author)
        //{
        //    foreach (var book in Books)
        //    {
        //        if (book.Author == author)
        //        {
        //            return book;
        //        }
        //    }
        //    return Book book;

        //}


    }
}
