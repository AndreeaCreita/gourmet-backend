using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

       
        public int UserId { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public string Nickname { get; set; }

        
        public User User { get; set; }
    }
}
