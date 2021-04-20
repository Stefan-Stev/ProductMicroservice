using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductDto>>
    {
        private readonly IApplicationContext context;
        private readonly IProductRepository repository;

        public GetProductsQueryHandler(IApplicationContext context,IProductRepository repository)
        {
            this.context = context;
            this.repository=repository;
        }

        public async Task<IEnumerable<GetProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = repository.GetAll();
            List<GetProductDto> listProducts=new List<GetProductDto>();
            foreach(var product in products)
                {
                

                List<int> ingredientsId = await context.IngredientFromProductProducts
                    .Where(p => p.ProductsId == product.Id)
                    .Select(p => p.IngredientsId)
                    .ToListAsync();
                GetProductDto productDto = new GetProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Discount = product.Discount
                };
                foreach (int i in ingredientsId)
                {
                    IngredientsFromProduct ingredient = await context
                        .Ingredients
                        .FindAsync(i);
                    productDto.Ingredients
                        .Add(new GetIngredientDto() { Id = ingredient.Id, Name = ingredient.Name });
                }
                listProducts.Add(productDto);


            }
            return listProducts.AsEnumerable();
        }
    }
}
