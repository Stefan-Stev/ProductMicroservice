using Domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Product 
    {
        public Product()
        {
            IngredientFromProductProducts = new HashSet<IngredientFromProductProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        [JsonIgnore]
        public virtual ICollection<IngredientFromProductProduct> IngredientFromProductProducts { get; set; }
    }
}
