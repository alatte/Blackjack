namespace Blackjack.Entities
{
    public class Player : Person
    {
        double Money;
        //SomeChanges
        //One more change
        public Player(string name, double money)
            : base(name)
        {
            this.Money = money;
        }

    }
}
