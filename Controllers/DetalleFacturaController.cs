using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roles.Data;
using Roles.Models;
using Roles.Models.Dto;

namespace Roles.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleFacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

   

        // GET: DetalleFactura
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<ClienteModels> ListaClientes()
        {
            return _context.Clientes.ToList();
        }

        public List<DtoDetalleFactura> Tabla()
        {
            /* var applicationDbContext =
                 _context.DetalleFactura
                 .Include(d => d.FacturaModel)
                 .Include(d => d.ProductoModels)
                 .Include(d => d.StockModel);


             return View(await applicationDbContext.ToListAsync());*/

            var dtf = _context.DetalleFactura
                .Include(d => d.FacturaModel)
                 .Include(d => d.ProductoModels)
                 .Include(d => d.StockModel);
            List<DtoDetalleFactura> dtofac = new List<DtoDetalleFactura>();

            foreach (var deta in dtf)
            {
                var dtoDetalle = new DtoDetalleFactura
                {
                    Cantidad = deta.Cantidad,
                    Id = deta.Id,
                    Nombre_Producto = deta.ProductoModels.NombreProductos,
                   // Precio = deta.valor,
                   // Total = deta.Cantidad * deta.valor
                };
                dtofac.Add(dtoDetalle);
            }

            return dtofac;
        }

      //  public  List<ClienteModels> ListaClientes()
       // {
           // return _context.Clientes.ToList();
       // }


        // GET: DetalleFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFacturaModels = await _context.DetalleFactura
                .Include(d => d.FacturaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFacturaModels == null)
            {
                return NotFound();
            }

            return View(detalleFacturaModels);
        }

        // GET: DetalleFactura/Create
        public IActionResult Create()
        {
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id");
            return View();
        }

        // POST: DetalleFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,valor,ProductoModelId,FacturaModelId,StocModelsId")] DetalleFacturaModels detalleFacturaModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFacturaModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFacturaModels.FacturaModelId);
            return View(detalleFacturaModels);
        }

        // GET: DetalleFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFacturaModels = await _context.DetalleFactura.FindAsync(id);
            if (detalleFacturaModels == null)
            {
                return NotFound();
            }
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFacturaModels.FacturaModelId);
            return View(detalleFacturaModels);
        }

        // POST: DetalleFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,valor,ProductoModelId,FacturaModelId,StocModelsId")] DetalleFacturaModels detalleFacturaModels)
        {
            if (id != detalleFacturaModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFacturaModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaModelsExists(detalleFacturaModels.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaModelId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFacturaModels.FacturaModelId);
            return View(detalleFacturaModels);
        }

        // GET: DetalleFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFacturaModels = await _context.DetalleFactura
                .Include(d => d.FacturaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFacturaModels == null)
            {
                return NotFound();
            }

            return View(detalleFacturaModels);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFacturaModels = await _context.DetalleFactura.FindAsync(id);
            if (detalleFacturaModels != null)
            {
                _context.DetalleFactura.Remove(detalleFacturaModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaModelsExists(int id)
        {
            return _context.DetalleFactura.Any(e => e.Id == id);
        }
    }
}
