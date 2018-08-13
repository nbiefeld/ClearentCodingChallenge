using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Classes
{
    public class CreditCardType : ICardType
    {
        public string Name { get; private set; }

        public float Interest { get; private set; }

        public List<ICard> Cards { get; private set; }

        public CreditCardType(string name, float interest)
        {
            Name = name;
            Interest = interest;
            Cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            Cards.Add(card);
        }

        public float CalculateInterest(int months)
        {
            return Cards.Sum(x => x.Interest(months, this));
        }
    }
}
