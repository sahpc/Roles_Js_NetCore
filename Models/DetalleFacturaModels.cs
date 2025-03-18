namespace Roles.Models
{
    public class DetalleFacturaModels
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public float valor { get; set; }

        //relations
        //product

        public int ProductoModelId { get; set; }
        public ProductoModels ProductoModels { get; set; }

        // FACTURA -----CABECEERA FACT

        public int FacturaModelId { get; set; }
        public FacturaModel FacturaModel { get; set; }

        //relations stock
        public int StocModelsId { get; set; }
        public StockModel StockModel { get; set; }
    }
}
