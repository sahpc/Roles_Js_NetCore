using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Roles.Models
{
    public class ProveedoresModels
    {
        public int Id { get; set; }
        [Display(Name ="Nombre del Proveedor")]
        [Required(ErrorMessage ="El campo es requerido")]
        [MinLength(3, ErrorMessage ="El campo requiere minimo 3 letras")]
        public int NombreProveedor { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(3, ErrorMessage = "El campo requiere minimo 3 letras")]
        public int Direccion { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(3, ErrorMessage = "El campo requiere minimo 3 letras")]
        public int Telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(3, ErrorMessage = "El campo requiere minimo 3 letras")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="No es un formato de correo electronico")]
        [Unicode]
        public int Correo { get; set; }


    }
}
