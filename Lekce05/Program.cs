namespace Lekce5
{
    class Program
    {
        // public static je jako globalni promenna.
        // Bude platna a k dispozici po celou dobu behu aplikace.
        // tato je private
        static float weight = 75;

        // zde muzeme videt, ze main nevraci zadnou hodnotu, protoze je void
        static void Main(string[] args)
        {
            ColorfulConsole.Print("Every program will start with this.", ConsoleColor.Blue);
            ColorfulConsole.Print("This is a fun story.", ConsoleColor.Green);
            ColorfulConsole.Print("But it had to end now.", ConsoleColor.Red);
            Console.ReadLine();

            // Priklad funkce - precte vstup a vypise ho
            //var input = Console.ReadLine();
            //Console.WriteLine(input);

            // vytiskne 75
            Console.WriteLine("Weight before: " + weight);

            // priklad toho, jak zadefinovat scope a v nem provest nejakou logiku (zmenit hodnotu promenne weight)
            // v praxi se takto nepouziva, ale pro ilustraci je to dobre - logicky jsme dokazali oddelit cast kodu. Pojdme si ji dat do funkce.
            {
                // pokud bych zde zadefinoval weight jako
                //float weight = 100; //tak by se nize vypsala 100
                weight = 100; // pri tomhle zapisu se pouzije globalni promenna weight
                float height = 1.619f;
                var bmi = weight / height / height;
            }

            // vytiskne 100
            Console.WriteLine("Weight after: " + weight);

            // pojdme si vyzkouset definici nejake funkce
            Something();

            // priklad funkce
            const float vatInCzechRepublic = 0.21f;
            const float pcPriceBeforeTaxes = 1000;
            var pcPriceAfterTaxes = CalculateAfterTaxes(pcPriceBeforeTaxes, vatInCzechRepublic);
            // pokud bychom chteli nyni zjistit cenu pc pri nemecke dani, staci nam zavolat funkci s nemeckou dani
            const float vatInGermany = 0.19f;
            double pcPriceAfterTaxesInGermany = CalculateAfterTaxes(pcPriceBeforeTaxes, vatInGermany);

            // vysvetleni a ukazka operatoru
            PrikladyOperatoru();

            // ukazka podminenych vyrazu
            PodmineneVyrazy();
        }

        private static float CalculateAfterTaxes(float priceBeforeTaxes, float vat)
        {
            var totalPrice = priceBeforeTaxes * (1 + vat);
            return totalPrice;
        }

        static void Something()
        {
            {
                float height = 1.619f;
                var bmi = weight / height / height;
            }
        }

        static void PrikladyOperatoru()
        {
            // aritmeticke - binarni -> + - * / %
            // napr. 2 + 3;
            // % (modulo) je zbytek po deleni
            //int zbytekPoDeleni = 10%3; -> hodnota bude 1

            // aritmeticke - unarni -> ++ --
            // je dulezita pozice operatoru (pred a za promennou)
            // napr. int a = 5; int b = a++; -> b = 5, a = 6

            // porovnavaci -> < > <= >=
            // porovnavaji cisla, dostavame bool (true/false)

            // logicke
            // && -> AND
            // || -> OR - true pokud alespon jeden z operandu je true
            // ! -> negace

            // operatory rovnosti
            // == -> rovnost
            // != -> nerovnost
        }

        static void PodmineneVyrazy()
        {
            var input = Console.ReadLine();
            int age = ParseAge(input); // funkce pro parsovani vstupu na int (precteni veku/cisla)

            string ageValue;
            // if podminka
            if (age == -1)
            {
                ageValue = "invalid";
            }
            else // else vetve. Muzeme i retezit vice else if
            {
                ageValue = age.ToString();
            }

            Console.WriteLine("Age is " + ageValue);

            // pro logicke porovnavani pouzivame && a ne &
            if (Check1() && Check2())
            {
                //..
            }

            Console.WriteLine("------------");

            // case priklad s dny v tydnu
            var weekDay = "Sunday";
            switch (weekDay)
            {
                case "Monday":
                    Console.WriteLine("It's Monday");
                    break; // vsimnete si nutnosti breaku
                case "Tuesday":
                    Console.WriteLine("It's Tuesday");
                    break;
                case "Wednesday":
                    Console.WriteLine("It's Wednesday");
                    break;
                case "Thursday":
                    Console.WriteLine("It's Thursday");
                    break;
                case "Friday":
                    Console.WriteLine("It's Friday");
                    break;
                case "Saturday":
                    Console.WriteLine("It's Saturday");
                    break;
                case "Sunday":
                    Console.WriteLine("It's Sunday");
                    break;
                default:
                    Console.WriteLine("It's not a day of the week");
                    break;
            }

            //switch priklad s propadavanim
            switch (weekDay)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    Console.WriteLine("Pracovni den");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("Vikend");
                    break;
                default:
                    Console.WriteLine("Necekana hodnota");
                    break;
            }
        }

        static bool Check1()
        {
            Console.WriteLine("Check1");
            return false;
        }

        static bool Check2()
        {
            Console.WriteLine("Check2");
            return true;
        }

        static int ParseAge(string input)
        {
            // pozastavit se u built-in funkci pro parsovani
            var isNumber = int.TryParse(input, out var age);

            // Pokud možné, je dobré ukončit funkci co nejdříve
            if (!isNumber) return -1; // pro jeden radek kodu jsou zavorky nepovinne
            bool isValidAge = age < 200 && age >= 0;
            if (!isValidAge) return -1;

            return age;
        }
    }
}
