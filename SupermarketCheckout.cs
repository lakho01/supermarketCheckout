using System;

public class SupermarketCheckout 
{
    static void Main(string[] args) 
    {
        SupermarketCheckout checkout = new SupermarketCheckout();
        Console.WriteLine("Item name | Quantity");
        checkout.addItem("Apple");
        checkout.addItem("Apple");
        checkout.addItem("Banana");
        checkout.addItem("Apple");
        Console.WriteLine("Total price: {0:0.00}", checkout.totalPrice()); //"Total price: 160 (130 + 30)"
    }

    // Initialize Item Array with some initial data load
    private readonly Item[] Items = new Item[]
    {
        new Item("Apple", 50.0, new SpecialOffer(3, 130)),
        new Item("Banana", 30.0, new SpecialOffer(2, 45)),
        new Item("Orange", 60.0, null),
        new Item("Strawberry", 99.0, null)
    };

    // Create basket and count number of items
    private int[] basket;

    public SupermarketCheckout()
    {
        basket = new int[Items.Length];
    }
    // Add an item to the basket
    public void addItem(String sku) {
      for (int i = 0; i < Items.Length; i++) {
        if (sku.Equals(Items[i].name)) {
          basket[i]++;
          //   Console.WriteLine("Item added to basket"); -- debugging
          break;
        }
      }
    }

    // Calculate price of items in the basket
    public double totalPrice() {
      double totalPrice = 0;
      for (int i = 0; i < Items.Length; i++) {
        int count = basket[i];
        Item item = Items[i];
        if (count > 0) {
          if (item.specialOffer != null && count >= item.specialOffer.quantity) {
            double numSpecialOffers = count / item.specialOffer.quantity;
            double numIndividualItems = count % item.specialOffer.quantity;
            totalPrice += numSpecialOffers * item.specialOffer.price
                + numIndividualItems * item.Price;
          } else {
            totalPrice += count * item.Price;
          }
        //   Console.WriteLine(item.name);
          Console.WriteLine(item.name + " | " + count);
        }
      }
      return totalPrice;
    }

    // Define specialOffer class
    private class SpecialOffer {
        public readonly int quantity;
        public readonly double price;

        public SpecialOffer(int quantity, double price) {
            this.quantity = quantity;
            this.price = price;
        }
    }
    // Define item class with item name, price and specialOffer
    private class Item {
        public readonly string name;
        public readonly double Price;
        public readonly SpecialOffer specialOffer;

        public Item(string name, double Price, SpecialOffer specialOffer) {
            this.name = name;
            this.Price = Price;
            this.specialOffer = specialOffer;
        }
    }
}
