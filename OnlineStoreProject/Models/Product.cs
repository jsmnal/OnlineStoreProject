using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Views { get; set; }
        public string ImagePath { get; set; }
        // Product can have one Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        // Product can have one Discount
        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }
        // Product can be ones in ShopBasketRow
        public ShopBasketRow ShopBasketRow { get; set; }
    }

}
