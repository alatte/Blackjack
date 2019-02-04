namespace Blackjack.Entities
{
    public class Player : Person
    {
        double Money;

        public Player(string name, double money)
            : base(name)
        {
            this.Money = money;
        }

    }
}
