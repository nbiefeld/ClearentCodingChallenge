using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Interfaces
{
    public interface IWallet
    {
        List<ICardType> CardTypes { get; }

        void AddCardType(ICardType cardType);

        float Interest(int months);
    }
}
