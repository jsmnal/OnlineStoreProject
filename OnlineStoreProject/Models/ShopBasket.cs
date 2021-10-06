using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Models
{
    public class ShopBasket
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        // ShopBasket can have many ShopBasketRows
        public List<ShopBasketRow> ShopBasketRow { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public OnlineStoreUser OnlineStoreUser { get; set; }

    }
}
