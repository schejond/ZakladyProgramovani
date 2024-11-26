//Ignorujme zatim using System;
using System;

// Ignorujme zatim namespace Lekce4
namespace Lekce4
{
    // Třída Program. Co to jsou trídy si vysvetlíme později. Zatím ignorujme.
    // Dulezite je vedet,  ze kazdy program potrebuje nejake misto, kde zacne.
    // pro konzolove aplikace je to vzdy funkce Main.
    // zminit i novy mozny zapis bez teto tridy

    class Program
    {
        // v C# komentare zacinaji dvema lomitky "//"
        /*
         * toto komentare na vice radku
         * zacinaji lomitkem a hvezdickou "/*"
         * a konci hvezdickou a lomitkem "* /" (bez mezery)
         */

        // Komentare jsou jen text, ktery se ignoruje, takze se pri exekuci kodu neprovedou a jsou preskoceny.
        // Spusteni z menu VS umisti aplikaci do debug modu.
        // Spusteni s "ctrl + F5" umisti aplikaci do release modu.

        // Kazda funkce ma nejaky vstupni bod
        // Vstupni bod konzolove aplikace je funkce Main
        // Piste kod pod timto komentarem, uvnitr Main
        static void Main(string[] args)
        {
            // pro nazvy promennych muzeme pouzivat: [aA-zZ], [0-9], _

            // PascalCase (prvni pismeno je velke a vsechna dalsi slova zacinaji velkym pismenem)
            // camelCase (prvni pismeno je male a vsechna dalsi slova zacinaji velkym pismenem)
            // snake_case (vsechna pismena jsou malymi pismeny a slova jsou oddelena podtrzitkem "_")
            // kebab-case (all words are separated by a dash "-")
            // kebab-case (vsechna pismena jsou malymi pismeny a slova jsou oddelena pomlckou "-")

            // V C# se pro nazvy promennych pouziva camelCase

            // celociselne hodnoty:
            // 32 bit
            int myAge = 26;
            // 64 bit
            long dloooouheCislo = 9999999999999999;

            // cisla s desetinnou casti:
            // floaty jsou rychle, 32 bit
            float weight = 80.5f;
            float height = 201.1f;

            // double je pomalejsi, 64 bit
            // double je defaultni typ pro praci s desetinnou casti
            double desetinneCislo = 2.5;

            // decimal je explicitne pouzivano pro penize a vedecke vypocty
            // zapis (decimal) znamena pretypovani z double na decimal
            // 128 bit
            decimal money = (decimal)10000000000000000000000.156465465465465464654654654654654654654654;

            // string se pouziva pro ulozeni textovych hodnot
            // pouzivame dvojite uvozovky ("")
            string myName = "Ondra";

            // char se pouziva pro ulozeni jednotlivych symbolu
            // pouzivame jednoduche uvozovky ('')
            char firstLetter = 'S';

            // pro binarni typy (logicke hodnoty - true nebo false) pouzivame boolean
            bool jePracovniDen = true;
            bool jeVikend = false;

            // var se pouziva jako alternativa k definici promenne s typem.
            var variablesDone = "Promenne umime!";
            // nejde pouzit pro neinicializovane promenne
            var timeNow = 10;

            // funkce pro vypis na konzoli
            Console.WriteLine(myName);

            // cisla muzeme scitat
            int sum = 1 + 5; // 6
            int sumx2 = sum + sum; // 12
            sumx2 = sumx2 * 2; // 24
            var sumMoreFloat = sumx2 + 2.0f;
            var sumMoreDecimal = (decimal)sumMoreFloat + (decimal)1.000001;
            Console.WriteLine(sumMoreDecimal);

            // muzeme stringy spojovat s dalsimi stringy a jinymi primitive typy tak, ze se vsechny zmeni na string
            var greetings = "Hello world!";
            var fullGreeting = myName + ", " + greetings;
            var fullGreetingTimes = fullGreeting + 1;
            Console.WriteLine(fullGreetingTimes);

            var a = 'a';
            // char + string = string
            // (int)char = ASCII 
            Console.WriteLine(a + " je " + (int)a);
            var b = 'b';
            Console.WriteLine(b + " je " + (int)b);
            // char + char = int
            var aAndB = a + b;
            Console.WriteLine("a + b =" + aAndB);
            Console.WriteLine("Ktery symbol je za 'Z' v ASCII?");
            // char + int = int
            var afterZ = Convert.ToChar('Z' + 1);
            Console.WriteLine("Odpoved: " + afterZ);

            // nejde odecitat stringy od sebe
            // kolik pismen je v abecede?
            Console.WriteLine("Pocet pismen v abecede:" + ('z' - 'a') + 1);

            // muzeme pouze nasobit a delit cisla
            // deleni integeru od integeru ignoruje desetinou cast
            var divisionResult = 1 / 100;
            Console.WriteLine(divisionResult);
            // deleni integeru od cisla s desetinnou casti si ponecha desetinnou cast
            var divisionResultFraction = 1 / 100.0;
            Console.WriteLine(divisionResultFraction);
            var hundred = 100;
            var hundredHundreds = hundred * 100.0f;
            Console.WriteLine(hundredHundreds);

            // hodnoty, ktere nechceme aby se menily, by mely byt definovany jako konstanty
            const double pi = 3.1415926535;

            Console.Write("Zadej sve jmeno: ");
            // Precte radek textu z konzole
            string name = Console.ReadLine();
            Console.WriteLine("Bud pozdraven " + name);
        }
    }
}
