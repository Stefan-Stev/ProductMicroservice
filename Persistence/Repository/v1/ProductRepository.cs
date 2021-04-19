using Application.Interfaces;
using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.v1
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext):base(productContext)
        {

        }
    }
}
