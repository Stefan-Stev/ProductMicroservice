using System.Collections.Generic;

namespace Domain.DTOs
{
    public class GetProductDto
    {
        public GetProductDto()
        {
            Ingredients = new List<GetIngredientDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public List<GetIngredientDto> Ingredients { get; set; }

    }
}
