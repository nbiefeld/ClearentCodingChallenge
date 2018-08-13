using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Classes
{
    public class Person : IPerson
    {
        public List<IWallet> Wallets { get; private set; }

        public Person()
        {
            Wallets = new List<IWallet>();
        }

        public void AddWallet(IWallet wallet)
        {
            Wallets.Add(wallet);
        }

        public float CalculateInterest(int months)
        {
            return Wallets.Sum(x => x.Interest(months));
        }
    }
}
