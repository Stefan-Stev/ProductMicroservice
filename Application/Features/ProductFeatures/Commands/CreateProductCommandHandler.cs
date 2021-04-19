using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
      
        private readonly IProductRepository repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            
            this.repository = repository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            Discount = request.Discount,
            Id=request.Id

            };

            repository.AddAsync(product);
            return product.Id;
        }
    }
}
