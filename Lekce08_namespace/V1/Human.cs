namespace Lekce8_namespace.V1
{
    class Human
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
            Console.WriteLine("Bla bla bla");
            Console.WriteLine("Bla bla bla");
            Console.WriteLine("Bla bla bla");
            Console.WriteLine("Bla bla bla");
            Console.WriteLine("Bla bla bla");
            Console.WriteLine("Bla bla bla");
        }
        public void Walk()
        {
            Console.WriteLine("Step step step");
            Console.WriteLine("Step step step");
            Console.WriteLine("Step step step");
            Console.WriteLine("Step step step");
            Console.WriteLine("Step step step");
            Console.WriteLine("Step step step");
        }
    }
}