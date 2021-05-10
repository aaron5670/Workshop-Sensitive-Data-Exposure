using System;

namespace WebshopDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var context = new MyContext();
            var customer = new Customer
            {
                CustomerId = 1,
                FirstName = "Elizabeth",
                LastName = "Lincoln",
                Address = "23 Tsawassen Blvd."
            };

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}