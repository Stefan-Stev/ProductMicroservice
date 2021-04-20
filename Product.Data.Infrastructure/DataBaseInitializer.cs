using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.Data.Infrastructure
{
    public class DataBaseInitializer
    {
        public static void Initialize(ProductContext context)
        {
            if(context.Products.Any())
            {
                return;
            }
            Seed(context);
        }

        private static void Seed(ProductContext context)
        {
            var products=new []
            {
                new Product
                {

                }
            }
        }
    }
}
