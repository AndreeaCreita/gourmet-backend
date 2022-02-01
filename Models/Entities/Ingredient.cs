using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}
