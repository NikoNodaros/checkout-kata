using CheckoutKata.Core.Interfaces;
using CheckoutKata.Core.Models;

[TestFixture]
public class CheckoutTests
{
    [Test]
    public void ScanSingleItemReturn37()
    {
        var pricingRules = new List<IPricingRule>();
        var checkout = new Checkout(pricingRules);
        checkout.Scan("A");
        Assert.That(37, Is.EqualTo(checkout.GetTotalPrice()));
    }
}