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
    public class ClienteController : Controller
    {
        //Database Context
        private TestContext _context;
        private readonly ILogger<ClienteController> _logger;

        //Constructor
        public ClienteController(ILogger<ClienteController> logger, TestContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.clientes
            .              OrderBy(x => x.Id);

            return View(clientes);
        }

        //Crear Cliente
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid) //Si hay éxito en el modelo
            {
                //Conversión y actualización de fechaNacimiento
                cliente.fechaNacimiento = createDateTime(cliente.stringfechaNacimiento);

                //Actualización de ID
                //Obtiene el último regitro actualizado
                var LastRegister = _context.clientes
            .                      OrderByDescending(x => x.Id)
                                    .FirstOrDefault(); 

                var ultimoId = LastRegister.Id;
                var nuevoId = (Int32.Parse(ultimoId)) + 1;
                cliente.Id = nuevoId.ToString();
                _context.clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //Editar Cliente
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Cliente clientetoUpdate)
        {
            if(ModelState.IsValid)
            {
                var clienteSearch = from c in _context.clientes
                                    where c.Id == clientetoUpdate.Id
                                    select c;

                var cliente = clienteSearch.SingleOrDefault();
                if(cliente!=null) //Si el cliente existe
                {
                    cliente.Id = clientetoUpdate.Id;
                    cliente.nombreCliente = clientetoUpdate.nombreCliente;
                    cliente.apellidoCliente = clientetoUpdate.apellidoCliente;
                    cliente.stringfechaNacimiento = clientetoUpdate.stringfechaNacimiento;
                    cliente.fechaNacimiento = createDateTime(clientetoUpdate.stringfechaNacimiento);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(clientetoUpdate);
        }
        //Eliminar Cliente
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Cliente clientetoDelete)
        {
            if(ModelState.IsValid)
            {
                var clienteSearch = from c in _context.clientes
                                    where c.Id == clientetoDelete.Id
                                    select c;
                if(clienteSearch.SingleOrDefault()!=null) //Si el cliente existe
                    _context.clientes.Remove(clienteSearch.SingleOrDefault());
                _context.SaveChanges();
                return View("Index",_context.clientes);
            }
            return View(clientetoDelete);
        }


        //Auxiliar methods
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
