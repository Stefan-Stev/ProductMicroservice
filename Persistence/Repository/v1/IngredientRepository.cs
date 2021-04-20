using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repository.v1
{
    public class IngredientRepository : Repository<IngredientsFromProduct>, IIngredientRepository
    {
        public IngredientRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
