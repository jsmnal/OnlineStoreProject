using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Models
{
    public class ShopBasketRow
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        // ShopBasketRow can have one Product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        // ShopBasketRow can have one ShopBasket
        public int ShopBasketId { get; set; }
        [ForeignKey("ShopBasketId")]
        public ShopBasket ShopBasket { get; set; }
    }
}
