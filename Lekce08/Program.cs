namespace Lekce8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // pole Animal objektu
            // instanci Animal mohu vytvorit pouze pokud Animal classa nebude abstraktni
            // Animal zvire = new Animal("Azor", 3);
            Animal[] animals = new Animal[2];
            // Mammal i Bird jsou child classy tridy Animal, proto mohu dat do Animal pole
            animals[0] = new Mammal("Azor", 3);
            animals[1] = new Bird("Parrot", 2, "Green");

            foreach (Animal animal in animals)
            {
                animal.Speak();
                // nemohu jen tak zavolat animal.Fly(), protoze Animal classa nema tuto metodu. Ma ji pouze bird
                // pokud bych to chtel udelat, tak bych musel pretypovat animal na Bird, coz muze byt nebezpecne pokud to je ve skutecnosti objekt typu napr. Mammal
                //Bird bird = (Bird)animal;
                //bird.Fly();

                // ovedomit si, jaky je rozdil kdyz volam virtual metodu kdyz chybi override a kdyz je override
            }
        }

        // ukazka - interface. Program pro souboje mezi bojovniky bude obsahovat nejakou logiku,
        // ktera simuluje souboj. Na vstupu tato cast aplikace potrebuje jen seznam bojovniku a aby
        // kazdy z nich byl schopen utocit a branit se. Jak toho dosahnout? Pomoci interface
        public void SimulateFight(ICombatant[] bojovnici)
        {
            foreach (ICombatant bojovnik in bojovnici)
            {
                bojovnik.Attack();
                bojovnik.Defend(5);
            }
        }
    }
}
