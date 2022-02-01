using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models.Entities
{
    public class User:IdentityUser<int>
    {
        public User() : base() { } //constructor

       public string Name { get; set; }

        

        public ICollection<Recipe> Recipes { get; set; }    //un user are mai multe retete
       
       public UserProfile UserProfile { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
