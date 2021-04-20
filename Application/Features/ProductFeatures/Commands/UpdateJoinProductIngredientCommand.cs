using MediatR;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateJoinProductIngredientCommand:IRequest<bool>
    {
        public int IngredientsId { get; set; }
        public int ProductsId { get; set; }
    }
}
