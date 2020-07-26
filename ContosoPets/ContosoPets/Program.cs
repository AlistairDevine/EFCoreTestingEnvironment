using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ContosoPets.Data;
using ContosoPets.Models;

namespace ContosoPets
{
    class Program
    {
        static void Main(string[] args)
        {
            using ContosoPetsContext context = new ContosoPetsContext();

            var squeakyBone = context.Products
                .Where(p => p.Name == "Squeaky Dog Bone")
                .FirstOrDefault();
            if (squeakyBone is Product)
            {
                //Edit entity records in the database
                //squeakyBone.Price = 7.99M;
                //Delete entity records from the database
                context.Remove(squeakyBone);
            }
            context.SaveChanges();

            //Display entity records from the database
            var products = context.Products
                .Where(p => p.Price >= 5.00M)
                .OrderBy(p => p.Name);

            foreach (Product p in products)
            {
                Console.WriteLine($"Id: {p.Id}");
                Console.WriteLine($"Name: {p.Name}");
                Console.WriteLine($"Price {p.Price}");
                Console.WriteLine(new string('-', 20));
            }



            //Add New products into database

            //Product squeakyBone = new Product()
            //{
            //    Name = "Squeaky Dog Bone",
            //    Price = 4.99M
            //};
            //context.Products.Add(squeakyBone);

            //Product tennisBalls = new Product()
            //{
            //    Name = "Tennis Ball 3-Pack",
            //    Price = 9.99M
            //};
            //context.Add(tennisBalls);

            //context.SaveChanges();

        }
    }
}
