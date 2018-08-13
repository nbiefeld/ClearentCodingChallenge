using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Interfaces
{
    public interface IPerson
    {
        List<IWallet> Wallets { get; }

        void AddWallet(IWallet wallet);

        float CalculateInterest(int months);
    }
}
