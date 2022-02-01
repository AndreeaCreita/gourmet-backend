using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }   
        public string Title { get; set; }

        public string Text { get; set; }

        //proprietate de navigare
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }


    }
}
