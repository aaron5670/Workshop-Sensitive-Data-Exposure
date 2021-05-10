using System;
using System.Linq;

namespace WebshopDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new MyContext();
            context.Customers.Add(new Customer
            {
                username = "john23",
                password = "welkom01",
                firstName = "John",
                lastName = "Doe",
                address = "Straatnaam 3",
            });
            context.SaveChanges();

            var customer1 = context.Customers.Single(c => c.customerId == 1);

            //password is stored unencrypted
            Console.WriteLine(customer1.password);
        }
    }
}