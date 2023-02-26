using NUnit.Framework;

[TestFixture]
public class SupermarketCheckoutTest
{
    [Test]
    public void TestGetTotalPriceWithoutOffer()
    {
        SupermarketCheckout checkout = new SupermarketCheckout();
        checkout.addItem("Apple");
        checkout.addItem("Banana");
        checkout.addItem("Apple");
        Assert.AreEqual(130.0, checkout.totalPrice(), 0.001);
    }

    [Test]
    public void TestGetTotalPriceWithOffer()
    {
        SupermarketCheckout checkout = new SupermarketCheckout();
        checkout.addItem("Apple");
        checkout.addItem("Banana");
        checkout.addItem("Apple");
        checkout.addItem("Apple");
        Assert.AreEqual(160.0, checkout.totalPrice(), 0.001);
    }
}
