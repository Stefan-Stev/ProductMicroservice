using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<IngredientsFromProduct> Ingredients { get; set; }
        DbSet<IngredientFromProductProduct> IngredientFromProductProducts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
