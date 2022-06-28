using ShoppingList.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Fiyat
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Ölçü birimleri
        /// </summary>
        public Mesures Mesures { get; set; }
        /// <summary>
        /// Özellik
        /// </summary>
        public string Feature { get; set; }
        /// <summary>
        /// Alındı mı?
        /// </summary>
        public bool IsReceived { get; set; }
        public Category Category { get; set; }
    }
}
