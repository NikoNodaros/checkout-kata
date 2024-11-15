using CheckoutKata.Core.Interfaces;

namespace CheckoutKata.Core.PricingRules
{
    public class UnitPriceRule : IPricingRule
    {
        private readonly string _sku;
        private readonly int _unitPrice;

        public UnitPriceRule(string sku, int unitPrice)
        {
            _sku = sku;
            _unitPrice = unitPrice;
        }

        public int CalculateTotal(IEnumerable<string> items)
        {
            int quantity = items.Count(item => item == _sku);
            return quantity * _unitPrice;
        }
    }
}