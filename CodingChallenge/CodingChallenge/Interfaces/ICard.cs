using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Interfaces
{
    public interface ICard
    {
        float Balance { get; }

        float Interest(int months, ICardType cardType);
    }
}
