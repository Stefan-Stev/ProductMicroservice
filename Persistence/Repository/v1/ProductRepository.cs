using Application.Interfaces;
using Domain;
using Persistence.Context;

namespace Persistence.Repository.v1
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext)
        {

        }
    }
}
