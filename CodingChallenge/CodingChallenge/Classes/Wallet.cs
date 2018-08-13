using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Classes
{
    public class Wallet : IWallet
    {
        public List<ICardType> CardTypes { get; private set; }

        public Wallet()
        {
            CardTypes = new List<ICardType>();
        }

        public void AddCardType(ICardType cardType)
        {
            CardTypes.Add(cardType);
        }

        public float Interest(int months)
        {
            return CardTypes.Sum(x => x.CalculateInterest(months));
        }
    }
}
