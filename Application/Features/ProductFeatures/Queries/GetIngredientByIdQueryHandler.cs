using Application.Interfaces;
using Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetIngredientByIdQueryHandler:IRequestHandler<GetIngredientByIdQuery,GetIngredientDto>
    {
        private readonly IIngredientRepository repository;
        public GetIngredientByIdQueryHandler(IIngredientRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetIngredientDto>  Handle(GetIngredientByIdQuery request,CancellationToken cancellation)
        {
            var ingredient = await repository.GetById(request.Id);
              
            var getIngredientDto = new GetIngredientDto()
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
            return getIngredientDto;
        }
    }
}
