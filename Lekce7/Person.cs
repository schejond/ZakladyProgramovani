namespace Lekce7
{
    // poradi vysvetleni: property, method, constructor, parametrized constructor
    //      encapsulation (zapouzdreni) - public, private
    //          gettery, settery
    //      ukazat vyznam static

    public class Person
    {
        private string _name;
        private string _surename;
        private DateTime _birthday;

        // toto je defaultni konstruktor
        // kazda classa (trida) ma defaultni konstruktor POKUD neni definovan custom (vlastni) konstruktor
        public Person()
        {
        }

        // parametrizovany konstruktor
        public Person(string name, DateTime birthday)
        {
            _name = name;
            _birthday = birthday;
        }

        // priklad metody
        public void Talk(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetClassName()
        {
            return "Person";
        }

        // diky teto definici je name read-only
        public string GetName()
        {
            return _name;
        }

        // metoda na zmenu hodnoty private property
        private void SetName(string name)
        {
            _name = name;
        }

        public void SetSurename(string surename)
        {
            _surename = surename;
        }

        public string GetSurename()
        {
            return _surename;
        }

        public string GetFullName()
        {
            return $"{_name} {_surename}";
        }

        // metoda na ziskani veku, kombinuje vice promennych z classy
        public int GetAge()
        {
            return (int)(DateTime.Now - _birthday).TotalDays / 365;
        }
    }
}