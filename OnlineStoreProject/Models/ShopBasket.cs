﻿using System;
using System.Collections.Generic;
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

    }
}
