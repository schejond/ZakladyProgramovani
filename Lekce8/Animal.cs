namespace Lekce8
{
    public abstract class Animal
    {
        protected string _name;

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        private int _age;

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        public Animal(string name, int age)
        {
            Console.WriteLine("Animal constructor");
            _name = name;
            _age = age;
        }

        // ukazka definice abstraktni metody
        // nema implementaci (telo)
        // implementace musi byt v child classe
        // tato classa musi byt oznacena jako abstract - jasne je tedy oznaceno, ze je neuplna. Nejde vytvorit jeji instance
        public abstract void Speak();

        public virtual void Move()
        {
            Console.WriteLine("Zvire dela pohyb");
        }
    }
}
