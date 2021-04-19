using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateJoinProductIngredientCommand:IRequest<bool>
    {
        public int IngredientsId { get; set; }
        public int ProductsId { get; set; }
    }
}
