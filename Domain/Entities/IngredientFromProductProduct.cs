using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public partial class IngredientFromProductProduct
    {
        public int IngredientsId { get; set; }
        public int ProductsId { get; set; }
        [JsonIgnore]
        public virtual IngredientsFromProduct Ingredients { get; set; }
        [JsonIgnore]
        public virtual Product Products { get; set; }
    }
}
