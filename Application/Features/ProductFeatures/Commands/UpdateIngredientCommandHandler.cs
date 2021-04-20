using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateIngredientCommandHandler:IRequestHandler<UpdateIngredientCommand,int>
    {
        private readonly IIngredientRepository repository;

        public UpdateIngredientCommandHandler(IIngredientRepository repository)
        {
            
            this.repository = repository;
        }
        public async Task<int> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = repository.GetById(request.Id).Result;

            if (ingredient == null)
            {
                throw new Exception("Product doesn't exist!");
            }

            ingredient.Id = request.Id;
            ingredient.Name = request.Name;
            await repository.UpdateAsync(ingredient);
            return ingredient.Id;
        }
    }
}
