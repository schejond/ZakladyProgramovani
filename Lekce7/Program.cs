// vysvetlit, co to je namespace
namespace Lekce7
{
    // ukazat si, ze i vstupni bod naseho programu je vlastne trida
    // koncovky pro soubory s tridami jsou .cs

    /*
     * internal vs. private vysvetleni:
     * internal je pro assembly scope (pouze pristupne z kodu ve stejnem .exe or .dll souboru (vystupni soubory po kompilaci))
     * private je pro class scope (pristup pouze z kodu stejne tridy (classy))
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            // zacneme postupnou definici tridy Person

            // vytvoreni objektu pomoci prazdneho konstruktoru
            var person = new Person();

            // pomoci parametrizovaneho konstruktoru
            var person1 = new Person("Jan", new DateTime(1998, 6, 16));
            
            // zavolani metody ("chovani") objektu
            person1.Talk("Ahoj!");

            // uprava private property pomoci metody
            person1.SetSurename("Novak");

            var person2 = new Person();

            Console.WriteLine($"{person1.GetFullName()} is {person1.GetAge()}");
            Console.WriteLine(person2.GetFullName());

            Console.WriteLine(Person.GetClassName());
        }
    }
}
