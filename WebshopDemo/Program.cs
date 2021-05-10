using System;
using System.Linq;

namespace WebshopDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.AddCustomer("john23", "welkom01", "John", "Doe", "Straatnaam 3");

            var customer = store.GetCustomerByUsername("john23");

            // password is stored unencrypted
            Console.WriteLine($"Password of {customer.username} is {customer.password}");

            var isAuthenticated = store.Authenticate("john23", "welkom01");
            Console.WriteLine($"Is user authenticated: {(isAuthenticated ? "yes" : "no")}");
        }

        public class Store
        {
            public void AddCustomer(string username, string password, string firstName, string lastName, string address)
            {
                using var context = new MyContext();
                
                // Hash password
                // Default workFactor is 11 (2,048 iterations)
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 11);

                context.Customers.Add(new Customer
                {
                    username = username,
                    password = passwordHash,
                    firstName = firstName,
                    lastName = lastName,
                    address = address
                });
                context.SaveChanges();
                Console.WriteLine($"User: {firstName} {lastName} added to database");
            }

            public Customer GetCustomerByUsername(string username)
            {
                using var context = new MyContext();
                var customer = context.Customers.SingleOrDefault(c => c.username == username);

                return customer;
            }

            public bool Authenticate(string username, string password)
            {
                using var context = new MyContext();

                // get account from database
                var account = context.Customers.SingleOrDefault(customer => customer.username == username);

                if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.password))
                {
                    // authentication failed
                    return false;
                }

                // authentication successful
                return true;
            }
        }
    }
}