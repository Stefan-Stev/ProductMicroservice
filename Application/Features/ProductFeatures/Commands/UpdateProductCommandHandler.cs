using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        
        private readonly IProductRepository productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            
            this.productRepository = productRepository;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = productRepository.GetById(request.Id).Result;

            if (product == null)
            {
                throw new Exception("Product doesn't exist!");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Discount = request.Discount;

            await productRepository.UpdateAsync(product);
            return product.Id;
        }
    }
}
