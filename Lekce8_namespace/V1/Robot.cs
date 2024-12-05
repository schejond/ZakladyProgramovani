namespace Lekce8_namespace.V1
{
    class Robot
    {
        private string _name;
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }

        public void Talk()
        {
            Console.WriteLine("Beep bop");
            Console.WriteLine("Beep bop");
            Console.WriteLine("Beep bop");
            Console.WriteLine("Beep bop");
            Console.WriteLine("Beep bop");
            Console.WriteLine("Beep bop");
        }

        public void Walk()
        {
            Console.WriteLine("Autobots rolling out!");
            Console.WriteLine("Autobots rolling out!");
            Console.WriteLine("Autobots rolling out!");
            Console.WriteLine("Autobots rolling out!");
            Console.WriteLine("Autobots rolling out!");
            Console.WriteLine("Autobots rolling out!");
        }
    }
}