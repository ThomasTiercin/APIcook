using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Models
{
    public class CookDbContext : DbContext
    {
        public DbSet<Measure> Measure { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<RecipeInstruction> RecipeInstruction { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketRecipeIngredient> BasketRecipeIngredient { get; set; }
        public DbSet<User> User { get; set; }
        public CookDbContext(DbContextOptions<CookDbContext> options)
            : base(options)
        { }

    }
}
