using System;
using System.Collections;

namespace Blackjack.Entities
{
    enum Suits
    {
        Spades = 9824,
        Clubs = 9827,
        Hearts = 9829,
        Diamonds = 9830
    }
    enum Values
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 10,
        Queen = 10,
        King = 10,
        Ace = 11
    }

    struct Card
    {
        internal Values Value { get; }
        internal int Suit { get; }

        internal Card(Values value, int suit)
        {
            this.Value = value;
            this.Suit = suit;
        }      
    }

    /*struct Card
     {
        private AbstractSuit suit;
        private AbstractValue value;

        public Card (CardFactory factory)
        {
            suit = factory.CreateSuit();
            value = factory.CreateValue();
        }
     }*/

    abstract class AbstractSuit
    {
        public abstract int GetSuit();
    }
    abstract class AbstractValue
    {
        public abstract Values GetValue();
    }

    class Suit : AbstractSuit
    {
        public override int GetSuit()
        {
            throw new System.NotImplementedException();
        }
    }
    class Value : AbstractValue
    {
        public override Values GetValue()
        {
            throw new System.NotImplementedException();
        }
    }

    abstract class AbstractCardFactory
    {
        public abstract IEnumerable CreateDeck();     
    }

    class CardFactory : AbstractCardFactory
    {
        public AbstractSuit CreateSuit()
        {
            return new Suit();
        }

        public AbstractValue CreateValue()
        {
            return new Value();
        }

        public override IEnumerable CreateDeck()
        {
            foreach (int suit in Enum.GetValues(typeof(Suits)))
                foreach (string value in Enum.GetNames(typeof(Values)))
                    yield return new Card((Values)Enum.Parse(typeof(Values), value), suit);
        }

    }
}