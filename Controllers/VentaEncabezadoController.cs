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
    public class VentaEncabezadoController : Controller
    {
        private readonly ILogger<VentaEncabezadoController> _logger;
        private TestContext _context;

        public VentaEncabezadoController(ILogger<VentaEncabezadoController> logger, TestContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ventasEncabezado = _context.ventasEncabezados
            .OrderBy(x => x.Id);

            return View(ventasEncabezado);
        }

        //Crear Encabezado de ventas
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VentaEncabezado venta)
        {
            if (ModelState.IsValid) //Si hay éxito en el modelo
            {
                var LastRegister = _context.ventasEncabezados
           .OrderByDescending(x => x.Id)
                                   .FirstOrDefault();

                var ultimoId = LastRegister.Id;
                var nuevoId = (Int32.Parse(ultimoId)) + 1;
                venta.Id = nuevoId.ToString();

                venta.fechaVenta = createDateTime(venta.stringFechaVenta);
                venta.fecha_reg = DateTime.Now;

                _context.ventasEncabezados.Add(venta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venta);
        }

        //Editar encabezado de Venta
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(VentaEncabezado ventaToUpdate)
        {
            if (ModelState.IsValid)
            {
                var ventaSearch = from v in _context.ventasEncabezados
                                  where v.Id == ventaToUpdate.Id
                                  select v;

                var venta = ventaSearch.SingleOrDefault();
                if (venta != null) //Si la venta existe
                {
                    venta.Id = ventaToUpdate.Id;
                    venta.clienteNombre = ventaToUpdate.clienteNombre;
                    venta.clienteApellido = ventaToUpdate.clienteApellido;
                    venta.descripcionVenta = ventaToUpdate.descripcionVenta;
                    venta.stringFechaVenta = ventaToUpdate.stringFechaVenta;
                    venta.fechaVenta = createDateTime(venta.stringFechaVenta);
                    venta.num_productos = ventaToUpdate.num_productos;
                    venta.totalVenta = ventaToUpdate.totalVenta;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ventaToUpdate);
        }

        //Eliminar Venta (Encabezado)
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(VentaEncabezado ventaToDelete)
        {
            if (ModelState.IsValid)
            {
                var ventaSearch = from v in _context.ventasEncabezados
                                  where v.Id == ventaToDelete.Id
                                  select v;

                //Elimina el Encabezado de la Venta
                if (ventaSearch.SingleOrDefault() != null) //Si el cliente existe
                    _context.ventasEncabezados.Remove(ventaSearch.SingleOrDefault());


                //Se busca en la tabla de Ventas Detalle el ID del encabezado
                var detallesSearch = from d in _context.ventasDetalles
                                     where d.Id == ventaToDelete.Id
                                     select d;

                if (detallesSearch != null) //Si encontró registros con el mismo ID
                {
                    foreach (var registro in detallesSearch)
                    {
                        Console.WriteLine("ID a eliminar: "+registro.Id);
                        _context.ventasDetalles.Remove(registro);
                    }
                }

                _context.SaveChanges();
                return View("Index", _context.ventasEncabezados);
            }
            return View(ventaToDelete);
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
