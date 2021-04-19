using Domain.DTOs;
using MediatR;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductDto>
    {
        public int Id { get; set; }
    }
}
