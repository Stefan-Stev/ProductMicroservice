using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public  class CreateIngredientCommandHandler:IRequestHandler<CreateIngredientCommand,int>
    {
        private readonly IApplicationContext context;

        public CreateIngredientCommandHandler(IApplicationContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(CreateIngredientCommand request, CancellationToken cancellation)
        {
            bool existsIngredient = context.Ingredients.Any(p => p.Id == request.Id);
            if (!existsIngredient)
            {
                var ingredient = new IngredientsFromProduct
                {
                    Id = request.Id,
                    Name = request.Name
                };
                context.Ingredients.Add(ingredient);
                await context.SaveChangesAsync();
               
                
                return ingredient.Id;
            }
            throw new Exception("Ingredient allready in database!");
        }



    }
}
