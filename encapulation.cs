
using System;

public class Product
{
    private string _name;
    private int _productId;
    private decimal _price;
    private int _quantity;
    
    public Product(string name, int productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetPrice()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetProductId()
    {
        return _productId;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return _streetAddress + "\n" + _city + ", " + _stateOrProvince + "\n" + _country;
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

public class Order
{
    private Product[] _products;
    private Customer _customer;
    private decimal _shippingCost;

    public Order(Product[] products, Customer customer)
    {
        _products = products;
        _customer = customer;
        _shippingCost = _customer.IsInUSA() ? 5 : 35;
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.GetPrice();
        }
        return totalPrice + _shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in _products)
        {
            packingLabel += "Name: " + product.GetName() + "\nID: " + product.GetProductId() + "\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Name: " + _customer.GetName() + "\n" + _customer.GetAddress().GetFullAddress();
        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create at least two orders with 2-3 products each
        Product[] products1 = { new Product("Shirt", 1234, 20.00m, 2), new Product("Pants", 5678, 30.00m, 1) };
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(products1, customer1);

        Product[] products2 = { new Product("Hat", 4321, 15.00m, 1), new Product("Socks", 8765, 5.00m, 3), new Product("Shoes", 2345, 50.00m, 1) };
        Address address2 = new Address("456 High St", "Anyville", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(products2, customer2);

        // Call methods to get packing label, shipping label, and total price of each order
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice() + "\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());

        Console.ReadLine();

        //This code creates classes for Product, Address, Customer, and Order, with appropriate members defined according to the specification. It also creates instances of these classes to generate orders based on products and customers.

//The Main() method creates at least two orders with a few products each, calculates the prices, and displays the information about the orders using appropriate methods.
    }
}