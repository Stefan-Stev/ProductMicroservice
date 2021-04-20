using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repository.v1
{
    public class JoinProductIngredientRepository : Repository<IngredientFromProductProduct>, IJoinProductIngredientRepository
    {
        public JoinProductIngredientRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
