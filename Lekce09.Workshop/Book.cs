namespace Lekce9.Workshop
{
    public class Book : Library
    {
        public string Title { get; init; }
        public string Author { get; init; }
        public int Year { get; init; }
        public string ISBN { get; init; }

        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }
    }
}
