namespace Roles.Models.Dto
{
    public class DtoDetalleFactura
            {
        public int Id { get; set; }
        public string Nombre_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Total { get; set; }
    }
}
