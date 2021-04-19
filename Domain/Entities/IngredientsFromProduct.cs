using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class IngredientsFromProduct
    {
        public IngredientsFromProduct()
        {
            IngredientFromProductProducts = new HashSet<IngredientFromProductProduct>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<IngredientFromProductProduct> IngredientFromProductProducts { get; set; }
    }
}
