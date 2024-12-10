namespace Lekce9.Workshop
{
    public class Library : ILibrary
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void LoadBooks(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(';');
                _books.Add(new Book(parts[0], parts[1], int.Parse(parts[2]), parts[3]));
            }
        }

        public List<Book> SearchBooks(string query)
        {
            return _books.FindAll(book => book.Title.Contains(query) || book.Author.Contains(query));
        }

        public void DisplayBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}, {book.Year} (ISBN: {book.ISBN})");
            }
        }
    }
}
