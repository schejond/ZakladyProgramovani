namespace Lekce8
{
    // interface je "recept" na to, co ma classa umet
    // interface muze odkazovat na dalsi jine interfacy
        // pak by byl zapis napr. takto: public interface ICombatant : IHealable, IRevivable
    public interface ICombatant
    {
        int Attack();

        void Defend(int damage);
    }
}
