using Domain;
using Domain.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<GetProductDto>>
    {
    }
}
