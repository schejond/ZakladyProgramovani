namespace Lekce9.Workshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the file path as a command-line argument.");
                return;
            }

            string fileName = args[0];
            ILibrary library = new Library();

            try
            {
                library.LoadBooks(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading _books: {ex.Message}");
                return;
            }

            while (true)
            {
                WriteOptions();

                switch (ReadIntUntilValid("Choose an option: "))
                {
                    case 1:
                        library.DisplayBooks();
                        break;
                    case 2:
                        var title = ReadStringUntilValid("Enter title: ");
                        var author = ReadStringUntilValid("Enter author: ");
                        var year = ReadIntUntilValid("Enter year: ");
                        var isbn = ReadStringUntilValid("Enter ISBN: ");
                        library.AddBook(new Book(title, author, year, isbn));
                        break;
                    case 3:
                        Console.Write("Enter search query: ");
                        var query = Console.ReadLine();
                        var results = library.SearchBooks(query);
                        foreach (var book in results)
                        {
                            Console.WriteLine($"{book.Title} by {book.Author}, {book.Year} (ISBN: {book.ISBN})");
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void WriteOptions()
        {
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Search Books");
            Console.WriteLine("4. Exit");
        }

        private static int ReadIntUntilValid(string initialMessage = "")
        {
            if (!string.IsNullOrWhiteSpace(initialMessage))
            {
                Console.Write(initialMessage);
            }

            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            return result;
        }

        private static string ReadStringUntilValid(string initialMessage = "")
        {
            if (!string.IsNullOrWhiteSpace(initialMessage))
            {
                Console.Write(initialMessage);
            }

            string? result = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("Invalid input. Please enter a non-empty string.");
                result = Console.ReadLine();
            }

            return result;
        }
    }
}
