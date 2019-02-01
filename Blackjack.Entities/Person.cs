namespace Blackjack.Entities
{
    public abstract class Person
    {
        internal string Name;
        internal Hand Hand;
        internal bool Status;
        internal bool Blackjack;

        internal Person(string name)
        {
            this.Name = name;
            Hand = new Hand();
            Status = true;
            Blackjack = false;           
        }       
    }
}
