using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class VentaDetalleController : Controller
    {
        private readonly ILogger<VentaDetalleController> _logger;
        private TestContext _context;

        public VentaDetalleController(ILogger<VentaDetalleController> logger, TestContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ventasDetalle = _context.ventasDetalles
                                .OrderBy(x => x.fechaVenta.Date);
            
            return View(ventasDetalle);
        }

        //Crear detalle de Venta
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VentaDetalle venta)
        {
            if (ModelState.IsValid) //Si hay éxito en el modelo
            {
                var LastRegister = _context.ventasDetalles
           .                        OrderByDescending(x => x.Id)
                                   .FirstOrDefault();
                var ultimoId = LastRegister.Id;
                var nuevoId = (Int32.Parse(ultimoId)) + 1;
                venta.Id = nuevoId.ToString();

                venta.fechaVenta = createDateTime(venta.stringFechaVenta);
                venta.fecha_reg = DateTime.Now;

                _context.ventasDetalles.Add(venta);
                _context.SaveChanges();
                return RedirectToAction("Index");     
            }
            return View(venta);
        }

        //Editar Detalle de Venta
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(VentaDetalle ventaToUpdate)
        {
            if (ModelState.IsValid)
            {
                var ventaSearch = from v in _context.ventasDetalles
                                  where v.clienteNombre == ventaToUpdate.clienteNombre
                                  && v.clienteApellido == ventaToUpdate.clienteApellido
                                  && v.producto == ventaToUpdate.producto
                                  && v.fechaVenta.Date == ventaToUpdate.fechaVenta.Date
                                  select v;

                var venta = ventaSearch.SingleOrDefault();
                if(venta!=null) //Si la venta existe
                {
                    venta.cantidad = ventaToUpdate.cantidad;
                    venta.impuesto = ventaToUpdate.impuesto;
                    venta.valorUnitario = ventaToUpdate.valorUnitario;
                    venta.valorTotal = ventaToUpdate.valorTotal;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ventaToUpdate);
        }


        //Auxiliar Methods
        public DateTime createDateTime(string fechaCompleta)
        {
            var fecha = fechaCompleta.Split("-");
            int anio = Int32.Parse(fecha[0]);
            int mes = Int32.Parse(fecha[1]);
            int dia = Int32.Parse(fecha[2]);
            var fechaNacimiento = new DateTime(anio, mes, dia);
            return fechaNacimiento;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
