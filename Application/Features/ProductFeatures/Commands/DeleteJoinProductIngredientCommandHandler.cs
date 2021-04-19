using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteJoinProductIngredientCommandHandler:IRequestHandler<DeleteJoinProductIngredientCommand,bool>
    {
        private readonly IApplicationContext context;

        public DeleteJoinProductIngredientCommandHandler(IApplicationContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(DeleteJoinProductIngredientCommand request, CancellationToken cancellationToken)
        {
            var relation = context.IngredientFromProductProducts.Where(s => s.ProductsId == request.ProductsId && s.IngredientsId == request.IngredientsId).FirstOrDefault();

            if (relation == null)
                throw new Exception("Table between this product and ingredietn doesn't exist");
            this.context.IngredientFromProductProducts.Remove(relation);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
