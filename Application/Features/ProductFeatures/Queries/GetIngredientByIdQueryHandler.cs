using Application.Interfaces;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetIngredientByIdQueryHandler:IRequestHandler<GetIngredientByIdQuery,GetIngredientDto>
    {
        private readonly IApplicationContext context;
        public GetIngredientByIdQueryHandler(IApplicationContext context)
        {
            this.context = context;
        }
        public async Task<GetIngredientDto>  Handle(GetIngredientByIdQuery request,CancellationToken cancellation)
        {
            var ingredient = await context.Ingredients.Where(i => i.Id == request.Id)
                                  .Select(i => new GetIngredientDto() { Id = i.Id, Name = i.Name }).FirstOrDefaultAsync();
            return ingredient;
        }
    }
}
