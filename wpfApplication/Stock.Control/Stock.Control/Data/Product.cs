using System;

namespace Stock.Control.Data
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Unit { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
