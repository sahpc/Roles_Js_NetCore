using System.ComponentModel.DataAnnotations;

namespace Roles.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public DateOnly FechaIngreso { get; set; }
        [Display(Name ="Numero de Factura")]
        public int NumeroFactura {get;set; }

        //relaciones
          //  cliente
          public int ClienteModelId { get; set; }
        public ClienteModels ClienteModels { get; set; }
    }
}
