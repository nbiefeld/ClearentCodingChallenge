using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Interfaces
{
    public interface ICardType
    {
        string Name { get; }

        float Interest { get; }

        List<ICard> Cards { get; }

        void AddCard(ICard card);

        float CalculateInterest(int months);
    }
}
