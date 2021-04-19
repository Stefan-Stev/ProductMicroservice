using Domain.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetIngredientsQuery:IRequest<IEnumerable<GetIngredientDto>>
    {
    }
}
