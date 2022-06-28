using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Entities
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Kategori Adı
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Ürün Listesi
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// Oluşturulma Tarihi
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Güncelleme Tarihi
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Not/tanımlama
        /// </summary>
        public string Description { get; set; }
    }
}
