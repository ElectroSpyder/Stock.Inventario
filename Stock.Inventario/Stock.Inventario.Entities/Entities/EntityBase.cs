using System;
using System.ComponentModel.DataAnnotations;

namespace Stock.Inventario.Entities.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
