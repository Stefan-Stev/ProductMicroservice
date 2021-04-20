using Domain;
using Persistence.Context;
using System.Linq;

namespace TestProject1
{
    public class DataBaseInitializer
    {
        public static void Initialize(ProductContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            Seed(context);
        }

        private static void Seed(ProductContext context)
        {
            var products = new[]
            {
                new Product
                {
                    Id=121,
                    Name="HotDog",
                    Price=12,
                    Description="Cel mai bun!",
                    Discount=0

                },
                new Product
                {
                    Id=122,
                    Name="HotDog2",
                    Price=13,
                    Description="Cel mai bun!",
                    Discount=2

                }

            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
