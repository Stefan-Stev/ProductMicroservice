using Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteIngredientCommandHandler:IRequestHandler<DeleteIngredientCommand,int>
    {
        private readonly IApplicationContext context;

        public DeleteIngredientCommandHandler(IApplicationContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteIngredientCommand request,CancellationToken cancellationToken)
        {
            var ingredient = context.Ingredients.Where(i => i.Id == request.Id).FirstOrDefault();
            if (ingredient == null)
            {
                throw new Exception("Product doesn't exist");
            }

            context.Ingredients.Remove(ingredient);
            await context.SaveChangesAsync();
            return ingredient.Id;
        }
    }
}
