using bun.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Models.Entities
{
    public class SessionToken
    {
        public SessionToken()
        {

        }
        public SessionToken(string jti, int userId, DateTime expirationDate) //mapeaza prop transmise in metoda, obiectului curent
        {
            this.Jti = jti;
            this.UserId = userId;
            this.ExpirationDate = expirationDate;
        }

        [Key]
        public string Jti { get; set; }  //id pentru token de aia e key deasupra
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } //proprietatea de navigare
    }
}
