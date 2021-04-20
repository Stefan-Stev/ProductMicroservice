using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        
        private readonly IProductRepository productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            
            this.productRepository = productRepository;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = productRepository.GetById(request.Id); 

            if (product == null)
            {
                throw new Exception("Product doesn't exist");
            }

            await productRepository.DeleteAsync(product.Result);
            
            return product.Result.Id;
        }
    }
}
