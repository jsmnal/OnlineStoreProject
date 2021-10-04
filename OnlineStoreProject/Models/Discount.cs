using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool ActivityState { get; set; }
        // Discount can have many Products
        public List<Product> Products { get; set; }
    }
}
