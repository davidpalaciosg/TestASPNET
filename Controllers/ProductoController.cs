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
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private TestContext _context;

        public ProductoController(ILogger<ProductoController> logger, TestContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var productos =  _context.productos
            .                OrderBy(x => x.Id);

            return View(productos);
        }
        //Crear Producto
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
             if (ModelState.IsValid) //Si hay éxito en el modelo
            {
                 var LastRegister = _context.productos
            .                      OrderByDescending(x => x.Id)
                                    .FirstOrDefault(); 
                var ultimoId = LastRegister.Id;
                var nuevoId = (Int32.Parse(ultimoId)) + 1;
                producto.Id = nuevoId.ToString();
                _context.productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        //Editar Producto
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Producto productoToUpdate)
        {
            if(ModelState.IsValid)
            {
                var productoSearch = from p in _context.productos
                                    where p.Id == productoToUpdate.Id
                                    select p;
                var producto = productoSearch.SingleOrDefault();
                if(producto!=null) //Si el producto existe
                {
                    producto.Id = productoToUpdate.Id;
                    producto.nombreProducto=productoToUpdate.nombreProducto;
                    producto.imagenProducto=productoToUpdate.imagenProducto;
                    producto.descripcionProducto=productoToUpdate.descripcionProducto;
                    producto.activo=productoToUpdate.activo;
                    producto.observacionesProducto=productoToUpdate.observacionesProducto;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(productoToUpdate);
        }

        //Eliminar Producto
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Producto productotoDelete)
        {
            if(ModelState.IsValid)
            {
                var productSearch = from p in _context.productos
                                    where p.Id == productotoDelete.Id
                                    select p;

                if(productSearch.SingleOrDefault()!=null) //Si el producto existe
                    _context.productos.Remove(productSearch.SingleOrDefault());

                _context.SaveChanges();
                return View("Index",_context.productos);
            }
            return View(productotoDelete);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
