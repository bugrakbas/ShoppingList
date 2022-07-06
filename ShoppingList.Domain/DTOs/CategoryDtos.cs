using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.DTOs
{
    public class CategoryDtos:BaseEntity
    {
        /// <summary>
        /// Kategori Adı
        /// </summary>
        public string CategoryName { get; set; }
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
