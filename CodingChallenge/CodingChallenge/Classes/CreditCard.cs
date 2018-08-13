using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Classes
{
    public class CreditCard : ICard
    {
        public float Balance { get; private set; }

        public CreditCard(float startingBalance)
        {
            Balance = startingBalance;
        }

        public float Interest(int months, ICardType cardType)
        {
            return months * cardType.Interest * Balance;
        }
    }
}
