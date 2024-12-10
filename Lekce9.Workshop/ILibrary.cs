namespace Lekce9.Workshop
{
    public interface ILibrary
    {
        void AddBook(Book book);

        void LoadBooks(string filePath);

        List<Book> SearchBooks(string query);

        void DisplayBooks();
    }
}
