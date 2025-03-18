using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace Roles.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Fabricación")]
        public DateOnly FechaFabricacion{ get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateOnly FechaCaducidad { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateOnly FechaRegistro { get; set; }

        ////Relaciones
        /////con producto
        public int ProductoModelsId { get; set; }
        public ProductoModels ProductoModels { get; set; }

        //CON PROVEEDOR
        public int PreedoresModelsId { get; set; }
        public ProveedoresModels ProveedoresModels { get; set; }

    }
}
