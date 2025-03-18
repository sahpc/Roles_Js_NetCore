using System.ComponentModel.DataAnnotations;

namespace Roles.Models
{
    public class ProductoModels
        
    {
        public int Id { get; set; }
        [Display(Name ="Nombre del Producto")]
        [MinLength(3)]
        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreProductos { get; set; }
        [Display(Name = "Presentación de Productos")]
        [MinLength(3)]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Presentacion { get; set; }
        [Display(Name = "Codigo de Barras")]
        [MinLength(5)]
    
        public string CodigoBarras { get; set; }
    }
}
