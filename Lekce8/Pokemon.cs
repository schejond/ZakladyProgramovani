namespace Lekce8
{
    // implementuje interface a tedy musi implementovat i jeho metody
    public class Pokemon : ICombatant
    {
        public int Attack()
        {
            Console.WriteLine("Pokemon attack");
            return 6;
        }

        public void Defend(int damage)
        {
            Console.WriteLine("Pokemon defend");
        }
    }
}
