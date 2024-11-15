using CheckoutKata.Core.Interfaces;
using CheckoutKata.Core.Models;
using CheckoutKata.Core.PricingRule;

namespace CheckoutKata.Tests.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private List<IPricingRule> _pricingRules;

        [SetUp]
        public void Setup()
        {
            _pricingRules = new List<IPricingRule>
        {
            new PricingRule("A", 50, 3, 130),
            new PricingRule("B", 30, 2, 45),
            new PricingRule("C", 20),
            new PricingRule("D", 15)
        };
        }

        [TestCase("", 0)]
        [TestCase("E", 0)]
        [TestCase("A", 50)]
        [TestCase("AB", 80)]
        [TestCase("CDBA", 115)]
        [TestCase("AA", 100)]
        [TestCase("AAA", 130)]
        [TestCase("AAAA", 180)]
        [TestCase("AAAAA", 230)]
        [TestCase("AAAAAA", 260)]
        [TestCase("AAAB", 160)]
        [TestCase("AAABB", 175)]
        [TestCase("AAABBD", 190)]
        [TestCase("DABABA", 190)]
        [TestCase("CC", 40)]
        [TestCase("DDDD", 60)]
        [TestCase("BBB", 75)]
        [TestCase("BBBB", 90)]
        [TestCase("CCCCCC", 120)]
        [TestCase("DDDDDDDD", 120)]
        [TestCase("AAABBB", 205)]
        [TestCase("AAABBBCCC", 265)]
        [TestCase("ABABABAB", 270)]
        [TestCase("AAABBCDDD", 240)]
        [TestCase("AAAAAAAAA", 390)]
        [TestCase("BBBBBB", 135)]
        [TestCase("CDBAEBF", 130)]
        [TestCase("AAABBBCCCDAA", 380)]
        [TestCase("ABCDABCDABCD", 310)]
        [TestCase("AAABBBAAABBB", 395)]
        [TestCase("DABABACAB", 290)]
        [TestCase("ABCABCABC", 265)]

        public void Test_TotalPrice(string items, int expectedTotal)
        {
            var checkout = new Checkout(_pricingRules);
            foreach (char item in items)
            {
                checkout.Scan(item.ToString());
            }
            Assert.That(expectedTotal, Is.EqualTo(checkout.GetTotalPrice()));
        }
    }
}