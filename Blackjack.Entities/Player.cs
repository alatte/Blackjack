namespace Blackjack.Entities
{
    public class Player : Person
    {
        double Money;
        //SomeChanges
        public Player(string name, double money)
            : base(name)
        {
            this.Money = money;
        }

    }
}
