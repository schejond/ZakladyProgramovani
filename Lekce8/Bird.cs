namespace Lekce8
{
    public class Bird : Animal
    {
        private string _color;

        public void Fly()
        {
            // pristup k _name je mozny, protoze je protected, kdyby byl private nepujde to
            Console.WriteLine("Ja jmenem" + _name + "letam!");
        }

        public Bird(string name, int age, string color) : base(name, age)
        {
            _color = color;
        }

        public override void Speak()
        {
            Console.WriteLine("Pip");
        }

        // musim dat klicove slovo override jinak se metoda z parent classy neprepise
        // mohu takto budto celou logiku parent classy prepsat, nebo jen rozsirit
        public override void Move()
        {
            // timto prikazem zavolam vykonani logiky z parent classy
            base.Move();

            Console.WriteLine("Ptak leti");
        }
    }
}
