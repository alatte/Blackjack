namespace Blackjack.Entities
{
    class Player : Person
    {
        double Money;

        internal Player(string name, double money)
            : base(name)
        {
            this.Money = money;
        }

    }
}
