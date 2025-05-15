using System.Diagnostics;

namespace Lekce6
{
    class Program
    {
        static int[] array; // priklad globalni promenne

        static void Main(string[] args)
        {
            // definice array
            var array = new int[3];
            array[0] = 1;
            array[1] = 10;
            array[2] = -5;

            // append to array ukazka
            // prazdne pole
            var array2 = new int[0];
            // nova array s jednim elementem 
            var expandedArray = AppendToArray(array, 10);

            // netiskneme array, tiskneme jeji prvky
            Console.WriteLine(array);

            foreach (var number in expandedArray)
            {
                Console.Write(number + " ");
            }

            // pojdme si ukazat, jak se upravuje pole a rozdil mezi predanim reference a predanim hodnoty (kopie)
            // ve funkci nize pracujeme s referenci
            DemoPassByReference();
            // ve funkci nize pracujeme s kopii
            // ukazeme si, praci se stringem jako s arrayi a problem s immutability (nemenitelnost)
            StringModificationExample();

            // ukazka rychlosti zpracovani pole
            CollectionProcessingComplexityComparison();

            // ukazka dalsich typu kolekci
            List<string> list = new List<string>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            HashSet<string> hashSet = new HashSet<string>();

            // ukazka zakladniho osetreni vstupu ve funkci (napr. kdyz je pole null apod.)
            string[] jmena = new string[2];
            jmena[0] = "Pavel";
            jmena[1] = "Pepa";
            PrintElementAtIndex(jmena, 1);

            // ukazka while cyklu
            int i = 0;
            while (i < jmena.Length)
            {
                Console.WriteLine(jmena[i]);
                i++;
            }

            // ukazka, jak debuggovat!

            // ukazka castych vyjimek
            ExceptionExample_NullReference();
            ExceptionExample_OutofRange();
        }

        private static int[] AppendToArray(int[] array, int numberToBeAdded)
        {
            // Expand the array
            var array2 = new int[array.Length + 1];
            // Copy elements over
            for (var i = 0; i < array.Length; i++)
            {
                array2[i] = array[i];
            }

            // Fill the last spot with the number to be added.
            array2[array2.Length - 1] = numberToBeAdded;

            return array2;
        }

        private static void DemoPassByReference()
        {
            var array = new[] { 1, 2, 3 };
            SetAllElementsOfArrayTo(array, 10);
            foreach (var number in array)
            {
                Console.Write(number + " ");
            }
        }

        private static void SetAllElementsOfArrayTo(int[] array, int number)
        {
            // toto nebude fungovat, protoze pracujeme s kopii elementu v poli, ne se samotnym elementem pole
            //foreach(var element in array)
            //{
            //    element = number;
            //}

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = number;
            }

            // neni potreba nic vracet, zmeny jsme aplikovali primo na puvodni pole
        }

        private static void StringModificationExample()
        {
            var name = "ondra";
            Console.WriteLine("Pred: " + name);
            CapitalizeFirstV1(name);
            // prints ondra
            Console.WriteLine("Po v1: " + name);

            name = CapitalizeFirstV2(name);
            // prints Ondra
            Console.WriteLine("Po v2: " + name);
        }

        private static void CapitalizeFirstV1(string name)
        {
            // nebude fungovat - string je immutable
            // name[0] = "O";

            var firstLetter = name[0].ToString().ToUpper();
            name = firstLetter + name.Substring(1, name.Length - 1);

            Console.WriteLine("Uvnitr v1 funkce: " + name);
        }

        private static string CapitalizeFirstV2(string name)
        {
            var firstLetter = name[0].ToString().ToUpper();
            name = firstLetter + name.Substring(1, name.Length - 1);

            Console.WriteLine("Uvnitr v2 funkce: " + name);

            return name;
        }

        public static void CollectionProcessingComplexityComparison()
        {
            // stopwatch pro mereni uplynuteho casu
            var sw = new Stopwatch();
            sw.Start();
            SlowSortedNumbersPrint();
            sw.Stop();
            Console.WriteLine("Pomaly sort trval: " + sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            FastSortedNumbersPrint();
            sw.Stop();
            Console.WriteLine("Rychly sort trval: " + sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private static void SlowSortedNumbersPrint()
        {
            int[] unsortedArray = new int[2048];

            Console.WriteLine("Prvnich 100 cisel je:");

            for (int i = 0; i < 99; i++)
            {
                // NECHCEME sortovat uvnitr loopu nebo delat jine slozite operace
                int[] sortedArray = Sort(unsortedArray);
                Console.WriteLine(sortedArray[i]);
            }
        }

        private static void FastSortedNumbersPrint()
        {
            int[] unsortedArray = new int[2048];

            Console.WriteLine("Prvnich 100 cisel je:");

            // nejprve seradime pole a pak ho vytiskneme
            int[] sortedArray = Sort(unsortedArray);
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine(sortedArray[i]);
            }
        }


        // nefunkcni sort, jde nam jen o to, mit funkci s vetsi komplexitou
        public static int[] Sort(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int ii = 0; ii < array.Length; ii++)
                {
                    result[ii] = ii;
                }
            }

            return result;
        }

        private static void PrintElementAtIndex(string[] poleZnaku, int index)
        {
            // osetreni vstupu
            if (poleZnaku == null || poleZnaku.Length == 0 || index >= poleZnaku.Length)
            {
                Console.WriteLine("Nespravny vstup.");
                return;
            }

            Console.WriteLine("Prvek na pozici " + index + " je " + poleZnaku[index]);
        }

        private static void ExceptionExample_NullReference()
        {
            Console.WriteLine(array[0]);
        }

        private static void ExceptionExample_OutofRange()
        {
            var array = new int[0];
            Console.WriteLine(array[0]);
        }
    }
}
