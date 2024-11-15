using CheckoutKata.Core.Interfaces;

namespace CheckoutKata.Core.PricingRule
{
    public class PricingRule : IPricingRule
    {
        private readonly string _sku;
        private readonly int _unitPrice;
        private readonly int? _specialQuantity;
        private readonly int? _specialPrice;

        public PricingRule(string sku, int unitPrice, int? specialQuantity = null, int? specialPrice = null)
        {
            _sku = sku;
            _unitPrice = unitPrice;
            _specialQuantity = specialQuantity;
            _specialPrice = specialPrice;
        }

        public int CalculateTotal(IEnumerable<string> items)
        {
            int quantity = items.Count(item => item == _sku);

            if (_specialQuantity.HasValue && _specialPrice.HasValue && quantity >= _specialQuantity.Value)
            {
                int specialSets = quantity / _specialQuantity.Value;
                int remainder = quantity % _specialQuantity.Value;
                return (specialSets * _specialPrice.Value) + (remainder * _unitPrice);
            }
            else
            {
                return quantity * _unitPrice;
            }
        }
    }
}
