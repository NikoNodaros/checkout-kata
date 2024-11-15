using CheckoutKata.Core.Interfaces;

namespace CheckoutKata.Core.Models
{
    public class Checkout : ICheckout
    {
        private readonly List<string> _items = new List<string>();
        private readonly IEnumerable<IPricingRule> _pricingRules;

        public Checkout(IEnumerable<IPricingRule> pricingRules)
        {
            _pricingRules = pricingRules;
        }

        public void Scan(string item)
        {
            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            return _pricingRules.Sum(rule => rule.CalculateTotal(_items));
        }

    }
}
