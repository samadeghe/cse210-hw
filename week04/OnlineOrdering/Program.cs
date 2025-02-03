using System;
using System.Collections.Generic;

namespace ProductOrderingSystem
{
    class Product
    {
        private string Name { get; set; }
        private string ProductId { get; set; }
        private decimal Price { get; set; }
        private int Quantity { get; set; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {ProductId})";
        }
    }

    class Address
    {
        private string StreetAddress { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string Country { get; set; }

        public Address(string streetAddress, string city, string state, string country)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Country = country;
        }

        public bool IsInUSA()
        {
            return Country.ToLower() == "usa";
        }

        public override string ToString()
        {
            return $"{StreetAddress}\n{City}, {State}\n{Country}";
        }
    }

    class Customer
    {
        private string Name { get; set; }
        private Address CustomerAddress { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            CustomerAddress = address;
        }

        public bool IsInUSA()
        {
            return CustomerAddress.IsInUSA();
        }

        public override string ToString()
        {
            return $"{Name}\n{CustomerAddress}";
        }
    }

    class Order
    {
        private List<Product> Products { get; set; }
        private Customer Customer { get; set; }

        public Order(Customer customer)
        {
            Products = new List<Product>();
            Customer = customer;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal productTotal = 0;
            foreach (var product in Products)
            {
                productTotal += product.GetTotalCost();
            }

            decimal shippingCost = Customer.IsInUSA() ? 5 : 35;
            return productTotal + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in Products)
            {
                label += $"- {product}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{Customer}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            var address1 = new Address("123 Main St", "Springfield", "IL", "USA");
            var address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

            // Create customers
            var customer1 = new Customer("John Doe", address1);
            var customer2 = new Customer("Jane Smith", address2);

            // Create orders
            var order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "A123", 999.99m, 1));
            order1.AddProduct(new Product("Mouse", "B456", 49.99m, 2));

            var order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", "C789", 799.99m, 1));
            order2.AddProduct(new Product("Headphones", "D012", 199.99m, 1));

            // Display order details
            var orders = new List<Order> { order1, order2 };

            foreach (var order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}\n");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
