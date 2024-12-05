namespace Lekce8_namespace.V2
{
    class DogRobot : Robot
    {
        public void Bite()
        {
            Console.WriteLine("Bite");
        }

        public void EmergencyShutdown()
        {
            Console.WriteLine("Sending data to factory...");
            Console.WriteLine("Shutting down...");
        }
    }
}