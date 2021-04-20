using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    class CreateJoinProductIngredientCommandHandler:IRequestHandler<CreateJoinProductIngredientCommand,bool>
    {
        private readonly IApplicationContext context;

        public CreateJoinProductIngredientCommandHandler(IApplicationContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(CreateJoinProductIngredientCommand request, CancellationToken cancellationToken)
        {
            bool alreadyExists = context.IngredientFromProductProducts.Any(s => s.ProductsId == request.ProductsId && s.IngredientsId == request.IngredientsId);
            if (alreadyExists)
                return false;
            var relation = new IngredientFromProductProduct
            {
                IngredientsId = request.IngredientsId,
                ProductsId = request.ProductsId
            };
            await context.IngredientFromProductProducts.AddAsync(relation);
            await context.SaveChangesAsync();
            return true;
        }
    }

}
