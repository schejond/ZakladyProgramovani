namespace Lekce13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ukazka prace s brake pointy, podminenymi break pointy a sledovanim promennych
            int i = 1;

            i = 5;
            InnerFunction();

            // Ukazka zalozeni testovaciho projektu
            // testy pro GradeCalculator
            // pouziti assert, testcase, test init, test cleanup
            // testovani vyjimek

            // ukazka mockovani zavislosti IDatabase na Calculator classe

            Console.WriteLine("Hello, World!");
        }

        private static void InnerFunction()
        {
            Console.WriteLine("Hello from inner function");
            Console.WriteLine("Hello from inner function 2");
        }
    }
}
