using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models.Entities
{
    public class IngredientRecipe
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        //legatura din cod pentru ele
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
