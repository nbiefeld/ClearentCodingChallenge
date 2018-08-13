using CodingChallenge.Classes;
using CodingChallenge.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    [TestFixture]
    class CreditCardTesting
    {
        ICardType visa, mastercard, discover;

        [SetUp]
        public void Setup()
        {
            visa = new CreditCardType("Visa", 0.10f);
            mastercard = new CreditCardType("MasterCard", 0.05f);
            discover = new CreditCardType("Discover", 0.01f);
        }

        [Test]
        public void TestCaseOne()
        {
            visa.AddCard(new CreditCard(100));
            mastercard.AddCard(new CreditCard(100));
            discover.AddCard(new CreditCard(100));

            var wallet = new Wallet();
            wallet.AddCardType(visa);
            wallet.AddCardType(mastercard);
            wallet.AddCardType(discover);

            var person = new Person();
            person.AddWallet(wallet);

            Assert.Multiple(() =>
            {
                // 1 month of interest for all three cards should equal $16
                Assert.That(person.CalculateInterest(1), Is.EqualTo(16.0f));

                Assert.That(visa.CalculateInterest(1), Is.EqualTo(10.0f));
                Assert.That(mastercard.CalculateInterest(1), Is.EqualTo(5.0f));
                Assert.That(discover.CalculateInterest(1), Is.EqualTo(1.0f));

            });
        }

        [Test]
        public void TestCaseTwo()
        {
            visa.AddCard(new CreditCard(100));
            mastercard.AddCard(new CreditCard(100));
            discover.AddCard(new CreditCard(100));

            var person = new Person();
            var walletA = new Wallet();
            walletA.AddCardType(visa);
            walletA.AddCardType(discover);

            person.AddWallet(walletA);

            var walletB = new Wallet();
            walletB.AddCardType(mastercard);
            person.AddWallet(walletB);

            Assert.Multiple(() =>
            {
                // 1 month of interest for all three cards should equal $16
                Assert.That(person.CalculateInterest(1), Is.EqualTo(16.0f));

                Assert.That(walletA.Interest(1), Is.EqualTo(11.0f));
                Assert.That(walletB.Interest(1), Is.EqualTo(5.0f));

            });
        }

        [Test]
        public void TestCaseThree()
        {
            var personA = new Person();
            var walletA = new Wallet();

            visa.AddCard(new CreditCard(100));
            mastercard.AddCard(new CreditCard(100));

            var mastercardA2 = new CreditCardType("MasterCard", 0.05f);
            mastercardA2.AddCard(new CreditCard(100));

            // Challenge states 'person 1 has 1 wallet , with 2 cards MC and visa'
            // I assume 2 MC and 1 visa with a total of three cards
            walletA.AddCardType(visa);
            walletA.AddCardType(mastercard);
            walletA.AddCardType(mastercardA2);
            personA.AddWallet(walletA);

            var personB = new Person();
            var walletB = new Wallet();

            var visaB = new CreditCardType("Visa", 0.10f);
            var mastercardB = new CreditCardType("MasterCard", 0.05f);

            visaB.AddCard(new CreditCard(100));
            mastercardB.AddCard(new CreditCard(100));

            walletB.AddCardType(visaB);
            walletB.AddCardType(mastercardB);
            personB.AddWallet(walletB);

            Assert.Multiple(() =>
            {
                Assert.That(personA.CalculateInterest(1), Is.EqualTo(20.0f));
                Assert.That(personB.CalculateInterest(1), Is.EqualTo(15.0f));

                Assert.That(walletA.Interest(1), Is.EqualTo(20.0f));
                Assert.That(walletB.Interest(1), Is.EqualTo(15.0f));

            });
        }
    }
}
