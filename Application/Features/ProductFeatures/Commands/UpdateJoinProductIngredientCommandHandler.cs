using Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateJoinProductIngredientCommandHandler:IRequestHandler<UpdateJoinProductIngredientCommand,bool>
    {
        private readonly IApplicationContext context;

        public UpdateJoinProductIngredientCommandHandler(IApplicationContext context)
        {
            this.context = context;
        }

        

        public async Task<bool> Handle(UpdateJoinProductIngredientCommand request, CancellationToken cancellationToken)
        {
            var relation = context.IngredientFromProductProducts.Where(s => s.ProductsId == request.ProductsId && s.IngredientsId == request.IngredientsId).FirstOrDefault();

            if (relation==null)
                throw new Exception("Table between this product and ingredietn doesn't exist");
            relation.IngredientsId = request.IngredientsId;
            relation.ProductsId = request.ProductsId;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
