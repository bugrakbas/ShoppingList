using ShoppingList.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Adı
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Soyadı
        /// </summary>
        public string SurName { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Şifre
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Rolü(Admin,Kullanıcı)
        /// </summary>
        public Roles Role { get; set; }

    }
}
