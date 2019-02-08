using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Blackjack.Entities
{
    //Нууууу... это шото очень сомнительное. Прям очень
    abstract class AbstractSuit
    {
        public abstract List<Suits> GetSuit();
    }
    abstract class AbstractValue
    {
        public abstract List<Values> GetValue();
    }

    class Suit : AbstractSuit
    {
        public override List<Suits> GetSuit()
        {
            return Enum.GetValues(typeof(Suits)).Cast<Suits>().ToList();
        }
    }
    class Value : AbstractValue
    {
        public override List<Values> GetValue()
        {
            return Enum.GetValues(typeof(Values)).Cast<Values>().ToList();
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
            List<Suits> suits = CreateSuit().GetSuit();
            List<Values> values = CreateValue().GetValue();

            return (values.SelectMany(value => suits, (value, suit) => new Card(value, (int)suit))).ToList();
        }
    }
}
