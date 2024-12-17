namespace Lekce10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enum demo
            // definice, custom indexy, prevod na int, string
            Console.WriteLine("fri: " + (int)WeekDay.Friday);
            Console.WriteLine("sat: " + (int)WeekDay.Saturday);
            Console.WriteLine("sun: " + (int)WeekDay.Sunday);
            Console.WriteLine("sunday string: " + WeekDay.Sunday);
            // vyuziti napr. pro switch statement
            WeekDay dayOfTheWeek = WeekDay.Monday;
            switch (dayOfTheWeek)
            {
                case WeekDay.Monday:
                    Console.WriteLine("Pondeli");
                    break;
                case WeekDay.Tuesday:
                    Console.WriteLine("Utery");
                    break;
                case WeekDay.Wednesday:
                case WeekDay.Thursday:
                    Console.WriteLine("Streda");
                    break;
            }

            // vysvetleni si out a discard operatoru
            string input = "123";
            bool isNumber = int.TryParse(input, out int _);

            // ukazka Listu a zakladnich metod: add, remove, contains, indexof
            List<int> cisla = new List<int>();
            cisla.Add(1);
            cisla.Add(-5);
            cisla.Add(-7);
            cisla.Add(9);
            //Console.WriteLine("index cisla 3: " + cisla.IndexOf(3));

            // LINQ - ukazka prace s LINQ extension metodami
            // LINQ metody pracuji nejcasteji s anonymnimi metodami, ale mohou pracovat i s normalnimi funkcemi, ktere
            // maji vhodnou signaturu (argumenty a navratovy typ)
            var x1 = cisla.Where(MojeFkce);
            // ukazka toho sameho pomoci lambda funkce (anonymni metody)
            var x2 = cisla.Where(x => x < 0);

            // any
            var x3 = cisla.Any(); // zjisti, zda jsou v pole nejake elementy
            var x4 = cisla.Any(x => x < 0); // zda jsou v poli elementy splnujici podminku

            List<Parent> parentList = new List<Parent>();
            // orderBy(serazeni napr.podle property objektu)
            var x5 = parentList.OrderBy(parent => parent.Age);

            // select = transformace dat
            var x6 = parentList.Select(parent => parent.Name); // trasnformace List<Parent> na List<string>

            // selectMany - transformace dat a spojeni vsech poli do jednoho
            var x7 = parentList.SelectMany(parent => parent.ChildrenNames);

            // LINQ funkce jdou jednoduse retezit za sebe
            var x8 = parentList.Where(parent => parent.Age > 18).Select(parent => parent.Name);

            // LINQ pracuje s IEnumerable. Funguje tzv. lazy evaluation - vyhodnocuje se az v momente, kdy je to potreba
            // napr. v momente, kdy se zavola .ToList() nebo foreach nebo .ToArray() apod.
        }

        private static bool MojeFkce(int x)
        {
            return x < 0;
        }
    }
}
