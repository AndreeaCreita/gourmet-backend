using bun.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models 
{

    //clasa care creeaza legatura dintre baza de date si entities
    public class AppDbContext : IdentityDbContext<User,Role,int,
        IdentityUserClaim<int>,UserRole,IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private object builder;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SessionToken> SessionTokens { get; set; }

        public override DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        //public object SessionTokens { get; internal set; }

        //user-role MAny To Many tabela comuna -> UserRole
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                ur.HasOne(ur => ur.Role).WithMany(ro => ro.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });

            //One to Many intre User si Recipe
            builder.Entity<User>()
                .HasMany(u => u.Recipes)
                .WithOne(r => r.User);

            //One to One intre User si UserProfile
            builder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User);

            //Many to Many intre Recipe si Ingredient
            builder.Entity<IngredientRecipe>().HasKey(ir => new { ir.RecipeId, ir.IngredientId });

            builder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Ingredient)
                .WithMany(i => i.IngredientRecipes)
                .HasForeignKey(ir => ir.IngredientId);

            builder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Recipe)
                .WithMany(r => r.IngredientRecipes)
                .HasForeignKey(ir => ir.RecipeId);


            
        }
    }
}
