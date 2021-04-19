using Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateIngredientCommandHandler:IRequestHandler<UpdateIngredientCommand,int>
    {
        private readonly IApplicationContext context;

        public UpdateIngredientCommandHandler(IApplicationContext  context)
        {
            this.context = context;
        }
        public async Task<int> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = context.Ingredients.Where(p => p.Id == request.Id).FirstOrDefault();

            if (ingredient == null)
            {
                throw new Exception("Product doesn't exist!");
            }

            ingredient.Id = request.Id;
            ingredient.Name = request.Name;
            await context.SaveChangesAsync();
            return ingredient.Id;
        }
    }
}
