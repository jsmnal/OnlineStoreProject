using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OnlineStoreProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Category can have many Products
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
