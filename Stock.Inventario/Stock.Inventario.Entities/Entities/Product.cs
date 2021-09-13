namespace Stock.Inventario.Entities.Entities
{
    using System;

    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public DateTime DateOfUpdate { get; set; }
    }
}
