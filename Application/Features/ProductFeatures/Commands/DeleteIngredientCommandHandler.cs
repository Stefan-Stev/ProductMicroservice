using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteIngredientCommandHandler:IRequestHandler<DeleteIngredientCommand,int>
    {
        
        private readonly IIngredientRepository repository;

        public DeleteIngredientCommandHandler(IIngredientRepository repository)
        {
            
            this.repository = repository;
        }
        public async Task<int> Handle(DeleteIngredientCommand request,CancellationToken cancellationToken)
        {
            var ingredient = repository.GetById(request.Id).Result;
            if (ingredient == null)
            {
                throw new Exception("Product doesn't exist");
            }

            await repository.DeleteAsync(ingredient);
            
            return ingredient.Id;
        }
    }
}
