using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdataProjectExample.Utilities.demoData
{
    public class DemoData
    {
        private Random rand = new Random();

        private readonly List<string> demoCustomers = new List<string>
        {
            "Foo",
            "Bar",
            "Acme",
            "King of Tech",
            "Awesomeness"
        };

        private readonly List<string> demoProducts = new List<string>
        {
            "Bike",
            "Car",
            "Apple",
            "Spaceship"
        };

        private readonly List<string> demoCountries = new List<string>
        {
            "AT",
            "DE",
            "CH"
        };

        public IEnumerable<Customer> GenerateDemoCustomers(int size) 
        {
            
            for (int i = 0; i < size; i++)
            {
                yield return new Customer
                {
                    Name = demoCustomers[rand.Next(demoCustomers.Count)],
                };
            }

        }

        public IEnumerable<Order> GenerateDemoOrders(int size, IEnumerable<Customer> customers = null) 
        {
            customers ??= GenerateDemoCustomers(size);

            for (int i = 0; i < size; i++)
            {
                var o = new Order
                {
                    OrderTime = DateTime.Today,
                    Product = demoProducts[rand.Next(demoProducts.Count)],
                    Quantity = rand.Next(1, 5),
                    Revenue = rand.Next(100, 5000),
                    Customer = customers.ElementAt(rand.Next(customers.Count())),
                };

                yield return o;
            }
        }

        public (IEnumerable<Customer>, IEnumerable<Order>) GenerateDemoData(int size) {
            var demoCustomers = GenerateDemoCustomers(size);
            var demoOrders = GenerateDemoOrders(size, demoCustomers);
            return (demoCustomers,demoOrders);
        }

    }
}
