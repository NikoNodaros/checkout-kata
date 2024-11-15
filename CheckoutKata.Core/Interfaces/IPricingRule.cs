using System.Collections.Generic;
namespace CheckoutKata.Core.Interfaces
{
    public interface IPricingRule
    {
        int CalculateTotal(IEnumerable<string> items);
    }
}