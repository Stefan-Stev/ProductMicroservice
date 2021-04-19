using MediatR;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteIngredientCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    
}
