using Domain.DTOs;
using MediatR;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetIngredientByIdQuery:IRequest<GetIngredientDto>
    {
        public int Id { get; set; }
    }
}
