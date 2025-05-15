namespace Lekce8
{
    public class Mammal : Animal
    {
        public Mammal(string name, int age) : base(name, age)
        {
            // logika konstuktoru child classy se provede az po logice konstuktoru parent classy
            Console.WriteLine("Mammal constructor");
        }

        public override void Speak()
        {
            Console.WriteLine("Zvuk savce :D");
        }
    }
}
