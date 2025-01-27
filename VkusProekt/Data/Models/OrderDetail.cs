﻿using System.Collections.Generic;
using System;

namespace VkusProekt.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int bludoID { get; set; }
        public uint price { get; set; }
        public virtual Bludo bludo { get; set; }
        public virtual Order order { get; set; }
    }
}
