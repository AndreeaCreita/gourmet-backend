using bun.Models.DTOs;
using bun.Models.Entities;
using bun.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public RecipeController(IRepositoryWrapper repo)
        {
            _repository = repo;
        }


        [HttpPost("create")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDTO dto_recipe)
        {
            var sender = await _repository.User.GetByIdAsync(Int32.Parse(User.Identity.Name));

            Recipe new_recipe = new Recipe();
            new_recipe.UserId = Int32.Parse(User.Identity.Name);
            new_recipe.Title = dto_recipe.Title;
            new_recipe.Text = dto_recipe.Text;
            new_recipe.User = sender;

            // User sender_user = _repository.User.fin
            Console.WriteLine("user " + User.Identity.Name + " created a recipe");

            _repository.Recipe.Create(new_recipe);

            await _repository.SaveAsync();

            var posting_user = await _repository.User.GetByIdAsync(Int32.Parse(User.Identity.Name));

            RecipeView rw = new RecipeView();
            rw.Username = posting_user.UserName;
            rw.Text = new_recipe.Text;
            rw.Title = new_recipe.Title;
            

            return Ok(rw);
        }


        [HttpGet("{userId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetRecipeByUserId(int userId)
        {
            var recipes = await _repository.Recipe.GetRecipesByUserId(userId);

            return Ok(recipes);
        }


        [HttpDelete("{recipeId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {
            var recipe = await _repository.Recipe.GetByIdAsync(recipeId);


            await _repository.SaveAsync();

            _repository.Recipe.Delete(recipe);

            await _repository.SaveAsync();

            return Ok(new { message = "Recipe deleted" });
        }


       

    }
    
}
