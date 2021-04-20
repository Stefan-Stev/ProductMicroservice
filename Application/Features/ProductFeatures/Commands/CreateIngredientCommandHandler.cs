using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public  class CreateIngredientCommandHandler:IRequestHandler<CreateIngredientCommand,int>
    {
        private readonly IIngredientRepository repository;

        public CreateIngredientCommandHandler(IIngredientRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(CreateIngredientCommand request, CancellationToken cancellation)
        {
          
            
                var ingredient = new IngredientsFromProduct
                {
                    Id = request.Id,
                    Name = request.Name
                };
                await repository.AddAsync(ingredient);
                
               
                
                return ingredient.Id;
            
        
        }



    }
}
