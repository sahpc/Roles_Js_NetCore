using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Roles.Models;

namespace Roles.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ProveedoresModels> Proveedores { get; set; }
    public DbSet<ProductoModels> Productos { get; set; }

    public DbSet<StockModel> Stocks { get; set; }

    public DbSet<ClienteModels>Clientes { get; set; }

    public DbSet<FacturaModel> Facturas { get; set; }

    public DbSet<DetalleFacturaModels> DetalleFactura { get; set; }
}
