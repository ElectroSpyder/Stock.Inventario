using System.ComponentModel.DataAnnotations;

namespace Stock.Inventario.Api.DTO
{
    public class ProductDto
    {
        [Required(ErrorMessage ="Debes ingresar un nombre")]
        public string Name { get; set; }

        [Display(Name = "Cantidad")]
        public int Stock { get; set; }

        [Display(Name="Descripción")]
        public string Description { get; set; }
        
    }
}
